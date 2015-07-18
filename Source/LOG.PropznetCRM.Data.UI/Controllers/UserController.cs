using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.ViewModels;
using Hangfire;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.Agent;
using LOG.PropznetCRM.Data.Model.CommunicationDetail;
using LOG.PropznetCRM.Data.ViewModel.Agent;
using LOG.PropznetCRM.Data.ViewModel.User;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class UserController : CRMBaseController
    {
        readonly Common.Auth.SingleTenant.Interfaces.Services.IAccountService _accountService;
        readonly IUserService _userService;
        readonly ICommunicationDetailService _communicationDetailService;
        readonly IAgentService _agentService;
        static string _returnUrl = "";
        public UserController(ICommunicationDetailService communicationDetailService,
            IAgentService agentService,
            IUserService userService,
            Common.Auth.SingleTenant.Interfaces.Services.IAccountService accountService
            )
        {
            _accountService = accountService;
            _communicationDetailService = communicationDetailService;
            _agentService = agentService;
            _userService = userService;
        }

        public ActionResult SignIn(string returnurl)
        {
            if (WebUser != null)
            {
                if (WebUser.Identity.IsAuthenticated)
                {
                    if (String.IsNullOrEmpty(returnurl))
                        return Redirect(_returnUrl);

                    return Redirect("Home/Index");
                }

                return View();
            }

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
                        if (String.IsNullOrEmpty(_returnUrl))
                            _returnUrl = "Home/Index";
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
                        BackgroundJob.Enqueue(() => EmailHelper.SendEmailForForgotPassword(recoverViewModel.Email, user.Name, newPassword));
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
                var agent = _agentService.GetAgentByUserId(WebUser.Id);
                var model = new AgentProfileViewModel()
                {
                    FirstName = agent.FirstName,
                    LastName = agent.LastName,
                    Phone = agent.CommunicationDetail.Phone,
                    Address = agent.CommunicationDetail.Address,
                    Email = agent.CommunicationDetail.Email,
                    Website = agent.CommunicationDetail.Website,
                    RERAregistrationNumber = agent.RERARegistrationNumber,
                    DEDlicenseNumber = agent.DEDLicenseNumber,
                    Image = agent.Image
                };
                return View(model);
            }
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public ActionResult UpdateProfile(AgentProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByUsername(WebUser.Email);
                var agent = _agentService.GetAgentByUserId(user.Id);
                var agentModel = new AgentModel
                {
                    Id = agent.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    DEDLicenseNumber = model.DEDlicenseNumber,
                    RERARegistrationNumber = model.RERAregistrationNumber,
                    UserId = user.Id,
                    CommunicationDetailID = agent.CommunicationDetailId,
                    IsListingMember = agent.IsListingMember,
                    Image = model.Image
                };
                var communicationDetailModel = new CommunicationDetailModel
                {
                    Id = agent.CommunicationDetailId,
                    Address = model.Address,
                    Phone = model.Phone,
                    Website = model.Website,
                    Email = model.Email
                };
                _communicationDetailService.UpdateCommunicationDetail(communicationDetailModel);
                _agentService.UpdateAgent(agentModel);
                ViewBag.Message = "Successfully updated your profile";
                ViewBag.Image = model.Image;
                WebUser.Image = model.Image;
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Common.Auth.SingleTenant.ViewModels.ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var passwordChangeStatus = _accountService.ChangePassword(WebUser.Email, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
                if (passwordChangeStatus)
                    ViewBag.Message = "Successfully changed your password";
                else
                    ViewBag.Message = "Sorry something bad occured, please try again later";
            }
            return View();
        }
        public ActionResult LogInUser(User user, string returnUrl)
        {
            var agent = _agentService.GetAgentByUserId(user.Id);
            var rolePermissions = _userService.GetAllUserPermissions(user.Id);
            var role = user.RoleMembers.FirstOrDefault().Role.Name;
            var expirationTime = Convert.ToInt32(ConfigurationManager.AppSettings["coockieTimeOut"]);
            var userInfo = new UserInfo { Id = user.Id, Name = user.Name, RefId = user.RefId, Email = user.Username, PermissionCodes = rolePermissions, Image = agent.Image, Role = role };
            Common.UI.Web.Infrastructure.HttpSessionWrapper.SetInSession(userInfo.RefId, userInfo);
            var serializeModel = new CRMPrincipal { Key = userInfo.RefId, PermissionCodes = rolePermissions, Image = agent.Image, Role = role };
            var serializer = new JavaScriptSerializer();
            var userData = serializer.Serialize(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, userInfo.Email, DateTime.Now, DateTime.Now.AddMinutes(expirationTime), false, userData);
            var eticket = FormsAuthentication.Encrypt(authTicket);
            var fcookie = new HttpCookie(FormsAuthentication.FormsCookieName, eticket);
            Response.Cookies.Add(fcookie);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
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