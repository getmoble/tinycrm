using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.User;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.ViewModel.User;
using CRMLite.Infrastructure;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;
using PropznetCommon.Features.CRM.ViewModel.Agent;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class UserApiController : BaseApiController
    {
        readonly IUserService _userService;
        readonly IPersonService _personService;
        readonly Common.Auth.SingleTenant.Interfaces.Services.IAccountService _accountService;
        public UserApiController(IUserService userService, IPersonService personService,
            Common.Auth.SingleTenant.Interfaces.Services.IAccountService accountService)
        {
            _userService = userService;
            _personService = personService;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult GetUser(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
          {
              var getuser = _userService.GetUserById(id);
              var user = new UserModel();
              if (getuser.Person != null)
              {
                  user.Address = getuser.Person.Address;
                  //user.Email = getuser.Person.Email;
                  user.FirstName = getuser.Person.FirstName;
                  user.Image = ImageUrlResolver.ResolveUrl(getuser.Person.Avatar);
                  user.LastName = getuser.Person.LastName;
                  user.PersonId = getuser.PersonId;
                  user.Phone = getuser.Person.PhoneNo;
                  if (getuser.AccessRule != null)
                  {
                      user.IsListingMember = getuser.AccessRule.IsApproved;
                  }
              }
              user.Id = getuser.Id;
              user.Email = getuser.Username;
              return user;
          }));
        }
        [HttpGet]
        public ActionResult List()
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var Userlist = _userService.GetAllUserByCreatedUserId(WebUser.Id);
                    var output = JsonConvert.SerializeObject(Userlist, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
                    var apiResult = new ApiResult<string>
                    {
                        Status = true,
                        Message = "Success",
                        Result = output
                    };
                    return Json(apiResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var userlist = _userService.GetAllUserDetails();
                    //var output = JsonConvert.SerializeObject(userlist);
                    //return Json(output, JsonRequestBehavior.AllowGet);
                    var output = JsonConvert.SerializeObject(userlist, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
                    var apiResult = new ApiResult<string>
                    {
                        Status = true,
                        Message = "Success",
                        Result = output
                    };
                    return Json(apiResult, JsonRequestBehavior.AllowGet);
                }

                },
                error =>
                {

                    var apiResult = new ApiResult<string>
                    {
                        Status = false,
                        Message = "Fail",
                        Result = ""
                    };
                return Json(apiResult);
                }));
        }
        [HttpGet]
        public ActionResult EditUser(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var user = _userService.GetUserById(id);
                user.Person.Avatar = ImageUrlResolver.ResolveUrl(user.Person.Avatar);
                return user;
            }));
        }
        public ActionResult UploadImageFiles()
        {
            var r = new List<UploadFileContentViewModel>();

            foreach (string file in Request.Files)
            {
                var hpf = Request.Files[file];
                if (hpf != null && hpf.ContentLength == 0)
                    continue;

                var savedFileName = Path.Combine(Server.MapPath("~/Upload/Avatar"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                r.Add(new UploadFileContentViewModel
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType,
                    Path = savedFileName
                });
            }
            // Returns json
            var vm = new UploadFileContentViewModel { Name = r[0].Name, Length = r[0].Length, Type = r[0].Type, Path = r[0].Path };
            return Json(vm);
        }
        [HttpPost]
        public ActionResult Create(PropznetCommon.Features.CRM.Model.User.UserModel userModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                if (userModel.Image != null)
                {
                    userModel.Image = userModel.Image.Split('\\').Last();
                }
                var roleId = new long[] { 3 };
                var result = _accountService.CreateAccount(userModel.FirstName, userModel.LastName, userModel.Email, "123456", roleId, userModel.Phone, userModel.Address, userModel.Image, userModel.IsListingMember, WebUser.Id);


                var output = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                var apiResult = new ApiResult<string>
                {
                    Status = true,
                    Message = "Success",
                    Result = output
                };
                return Json(apiResult, JsonRequestBehavior.AllowGet);                   
            },
            error =>
            {

                var apiResult = new ApiResult<string>
                {
                    Status = false,
                    Message = "Fail",
                    Result = ""
                };
             return Json(apiResult);
            }));
        }

        [HttpPost]
        public ActionResult Search(UserSearchFilter userSearchFilter)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                userSearchFilter.UserId = WebUser.Id;
                var searchResult = _userService.SearchUser(userSearchFilter, 0, 0);
                return searchResult.Items;
            }));
        }
        [HttpPost]
        public ActionResult GetDelete(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var deletestatus = _accountService.DeleteAccount(id);
                return deletestatus;
            }));
        }
        [HttpPost]
        public ActionResult Update(PropznetCommon.Features.CRM.Model.User.UserModel userModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                if (!String.IsNullOrEmpty(userModel.Image))
                {
                    if (userModel.Image.Contains("C:\\fakepath\\"))
                        userModel.Image = userModel.Image.Split('\\').Last();
                    if (userModel.Image.Contains("/Upload/Avatar/"))
                        userModel.Image = userModel.Image.Split('/').Last();
                }

                var result = _accountService.UpdateAccount(userModel.FirstName, userModel.LastName, userModel.Email, userModel.Id, userModel.Phone, userModel.Address, userModel.Image, userModel.IsListingMember);
                return result;
            }));
        }
    }
}