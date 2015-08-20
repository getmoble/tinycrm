using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.ViewModels;
using Common.UI.Web.Infrastructure;
using Hangfire;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.User;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.ViewModel.User;
using CRMLite.Infrastructure;
using ChangePasswordViewModel = Common.Auth.SingleTenant.ViewModels.ChangePasswordViewModel;
using IAccountService = Common.Auth.SingleTenant.Interfaces.Services.IAccountService;

namespace CRMLite.UI.Controllers
{
    public class UserController : BaseUIController
    {
        readonly IAccountService _accountService;
        readonly IUserService _userService;
        readonly IPersonService _personDetailService;
        static string _returnUrl = "";
        public UserController(IPersonService personService,
            IUserService userService,
            IAccountService accountService)
        {
            _accountService = accountService;
            _personDetailService = personService;
            _userService = userService;
        }

        public ActionResult SignIn(string returnurl)
        {
            if (WebUser != null)
            {
                if (WebUser.Identity.IsAuthenticated)
                {
                    if (!string.IsNullOrEmpty(returnurl))
                        return Redirect(_returnUrl);
                    _returnUrl = returnurl;
                    return RedirectToAction("Index", "Home", new { area = "CRM" });
                }

                return View();
            }
            _returnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isValid = _accountService.ValidateUser(signInViewModel.Username, signInViewModel.Password);
                    if (isValid)
                    {
                        var user = _userService.GetUserByUsername(signInViewModel.Username);
                        LogInUser(user, _returnUrl);
                        if (string.IsNullOrEmpty(_returnUrl))
                            _returnUrl = "/CRM/Home/Index";
                        return Redirect(_returnUrl);
                    }

                    ViewBag.Message = "Sorry, Invalid Credentials";
                }

                catch (Exception ex)
                {
                    ViewBag.Message = "Sorry, You are not a valid user";
                }
            }
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(RecoverPasswordViewModel recoverViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userService.GetUserByUsername(recoverViewModel.Email);
                    if (user != null)
                    {
                        string newPassword = _accountService.ResetPassword(recoverViewModel.Email);
                        BackgroundJob.Enqueue(() => EmailHelper.SendEmailForForgotPassword(recoverViewModel.Email, SiteSettings.FromAddress, SiteSettings.AppName, user.Name, newPassword));
                    }
                    else
                        ViewBag.Message = "Sorry, this email doesn't exist";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Sorry, this email doesn't exist";
                }
            }
            else
                return View();
            return View();
        }
        [HttpGet]
        public ActionResult UpdateProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userService.GetUserById(WebUser.Id);
                var model = new UserProfileViewModel()
                {
                    FirstName = user.Person.FirstName,
                    LastName = user.Person.LastName,
                    Phone = user.Person.PhoneNo,
                    Email = user.Person.Email,
                    Address = user.Person.Address,
                    Image = user.Person.Avatar
                };
                return View(model);
            }
            return RedirectToAction("SignIn");
        }
        [HttpPost]
        public ActionResult UpdateProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                long[] roleId = WebUser.RoleId;
                var user = _userService.GetUserByUsername(WebUser.Email);
                //if (WebUser.IsInRole("Admin"))
                //{
                //    roleId = new long[] { 1 };
                //}
                _accountService.UpdateAccount(model.FirstName + "" + model.LastName, WebUser.Email, WebUser.Email, model.Address, model.Phone, roleId, user.PersonId, WebUser.Id, model.Image);
                ViewBag.Message = "Successfully updated your profile";
                ViewBag.Image = model.Image;
                WebUser.Image = model.Image;
                WebUser.Name = model.FirstName;
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var passwordChangeStatus = _accountService.ChangePassword(WebUser.Email, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
                if (passwordChangeStatus)
                    ViewBag.ChangedMessage = "Successfully changed your password";
                else
                    ViewBag.Message = "Sorry, passwords don't match ! ";
            }
            return View();
        }
        public ActionResult LogInUser(User user, string returnUrl)
        {
            var rolePermissions = _userService.GetAllUserPermissions(user.Id);
            var roleIds = new long[user.RoleMembers.Count];
            int i = 0;
            foreach (var roleMembers in user.RoleMembers)
            {
                roleIds[i] = roleMembers.RoleId;
                i++;
            }
            if (roleIds.Length>0)
            {
                var expirationTime = SiteSettings.CoockieTimeOut;
                var userInfo = new UserInfo { Id = user.Id, Name = user.Name, RefId = user.RefId, Email = user.Username, PermissionCodes = rolePermissions, Image = user.Person.Avatar,RoleId=roleIds };
                HttpSessionWrapper.SetInSession(userInfo.RefId, userInfo);
                var serializeModel = new UserCoockieData { Key = userInfo.RefId };
                //var serializeModel = new CRMLitePrincipal { Key = userInfo.RefId, PermissionCodes = rolePermissions, Image = user.Person.Avatar, RoleId = roleIds };
                var serializer = new JavaScriptSerializer();
                var userData = serializer.Serialize(serializeModel);
                var authTicket = new FormsAuthenticationTicket(1, userInfo.Email, DateTime.Now, DateTime.Now.AddMinutes(expirationTime), false, userData);
                var eticket = FormsAuthentication.Encrypt(authTicket);
                var fcookie = new HttpCookie(FormsAuthentication.FormsCookieName, eticket);
                Response.Cookies.Add(fcookie);
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return RedirectToAction("SignIn", "User");
        }
        public ActionResult UploadFile()
        {
            var fileName = "";
            var hpf = Request.Files[0];
            if (hpf != null && hpf.ContentLength != 0)
            {
                var guid = Guid.NewGuid();
                var savedFileName = Server.MapPath(ImageUrlResolver.ResolveUrl(guid + hpf.FileName));
                hpf.SaveAs(savedFileName);
                fileName = guid + hpf.FileName;
            }
            return Json(fileName, JsonRequestBehavior.AllowGet);
        }
    }
}