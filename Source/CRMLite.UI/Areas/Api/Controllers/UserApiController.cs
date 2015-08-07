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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetUser(long id)
        {
            var user = _userService.GetUserById(id);
            user.Person.Avatar = ImageUrlResolver.ResolveUrl(user.Person.Avatar);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult List()
        {
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {

                    var Userlist = _userService.GetAllUserByCreatedUserId(WebUser.Id);
                    //var output = JsonConvert.SerializeObject(Userlist);
                    //return Json(output, JsonRequestBehavior.AllowGet);

                    var output = JsonConvert.SerializeObject(Userlist, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });
                    return Json(output, JsonRequestBehavior.AllowGet);

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
                    return Json(output, JsonRequestBehavior.AllowGet);
                }
            },
             () =>
             {
                 return Json(false, JsonRequestBehavior.AllowGet);
             },
             error => { return Json(false, JsonRequestBehavior.AllowGet); 
             });
        }
        public ActionResult EditUser(long id)
        {
            var user = _userService.GetUserById(id);
            user.Person.Avatar = ImageUrlResolver.ResolveUrl(user.Person.Avatar);
            return Json(user, JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(PropznetCommon.Features.CRM.Model.User.UserModel userModel)
        {
            if (userModel.Image != null)
            {
                userModel.Image = userModel.Image.Split('\\').Last();
            }
            var roleId=new long[] {3};          
            _accountService.CreateAccount(userModel.FirstName,userModel.LastName,userModel.Email,"123456",roleId,userModel.Phone,userModel.Address,userModel.Image,userModel.IsListingMember);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(UserSearchFilter userSearchFilter)
        {
            userSearchFilter.UserId = WebUser.Id;
            var searchResult = _userService.SearchUser(userSearchFilter, 0, 0);
            return Json(searchResult.Items, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDelete(long id)
        {
            var deletestatus = _accountService.DeleteAccount(id);
            return Json(deletestatus);
        }
        public ActionResult Update(PropznetCommon.Features.CRM.Model.User.UserModel userModel)
        {
            var personModel = new PersonModel
            {
                Id = userModel.Id,
                Address = userModel.Address,
                Email = userModel.Email,
                PhoneNo = userModel.Phone
            };

            if (!String.IsNullOrEmpty(userModel.Image))
            {
                if (userModel.Image.Contains("C:\\fakepath\\"))
                    userModel.Image = userModel.Image.Split('\\').Last();
                if (userModel.Image.Contains("/Upload/Avatar/"))
                    userModel.Image = userModel.Image.Split('/').Last();
            }

            var person = _personService.UpdatePerson(personModel);
            userModel.PersonId = person.Id;            

            var Userupdate = _accountService.UpdateAccount(userModel.FirstName,userModel.LastName,userModel.Email,userModel.Id,userModel.Phone,userModel.Address,userModel.Image,userModel.IsListingMember);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}