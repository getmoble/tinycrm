using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Common.Settings.Interfaces.Services;
using CRMLite.Infrastructure;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class SettingManageController : BaseApiController
    {
        //
        // GET: /Api/SettingsApi/

        readonly ISettingService _settingsService;
        public SettingManageController(ISettingService settingsService)
        {
            _settingsService = settingsService;
        }
        [HttpPost]
        public ActionResult ChangePagingSize(int pagingsize)
        {
            _settingsService.UpdateSetting("pagingsize", pagingsize.ToString());
            return Json(true);
        }
         [HttpPost]
        public ActionResult ChangeLogo()
        {
                var hpf = Request.Files[0] as HttpPostedFileBase;
                if (hpf != null && hpf.ContentLength != 0)
                {
                    var guid = Guid.NewGuid();
                    var savedFileName = Path.Combine(Server.MapPath(ImageUrlResolver.ThumbNail()), Path.GetFileName(guid + hpf.FileName));
                    hpf.SaveAs(savedFileName);
                    var img = new Bitmap(savedFileName);
                    if (img.Height >= SiteSettings.LogoMaxHeight && img.Width >= SiteSettings.LogoMaxWidth)
                    {
                        img.Dispose();
                        var i1 = new ImageResizer.ImageJob(savedFileName, Server.MapPath(ImageUrlResolver.ThumbNail()) + guid + hpf.FileName, new ImageResizer.ResizeSettings(
                       "maxwidth=" + SiteSettings.LogoMaxWidth + "&maxheight=" + SiteSettings.LogoMaxHeight + ";mode=stretch")) { CreateParentDirectory = true };
                        i1.Build();
                        _settingsService.UpdateSetting("logo", guid + hpf.FileName);
                        string error = "New logo updated successfully";
                        JsonResult result = Json(error, JsonRequestBehavior.AllowGet);
                        return result;
                    }
                    else
                    {
                        img.Dispose();
                        var info = new FileInfo(savedFileName);
                        if (info.Exists)
                        {
                            info.Delete();
                        }
                        string error = "error:your file is too small !";
                        JsonResult result= Json(error, JsonRequestBehavior.AllowGet);
                        return result;
                    }
                }
                return Json(true);
        }
	}
}