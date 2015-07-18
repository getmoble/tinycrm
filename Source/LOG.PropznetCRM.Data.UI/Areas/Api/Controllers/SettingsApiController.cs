using Common.Settings.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Areas.Api.Controllers
{
    public class SettingsApiController : Controller
    {
        readonly ISettingService _settingsService;
        public SettingsApiController(ISettingService settingsService)
        {
            _settingsService = settingsService;
        }
        public ActionResult ChangePagingSize(int pagingsize)
        {
            _settingsService.UpdateSetting("pagingsize", pagingsize.ToString());
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeLogo()
        {
            var hpf = Request.Files[0];
            if (hpf != null && hpf.ContentLength != 0)
            {
                var guid = Guid.NewGuid();
                var savedFileName = Path.Combine(Server.MapPath(ImageUrlResolver.ThumbNail()), Path.GetFileName(guid + hpf.FileName));
                hpf.SaveAs(savedFileName);
                var img = new Bitmap(savedFileName);
                if (img.Height >= Int32.Parse(ConfigurationManager.AppSettings["logomaxheight"]) && img.Width >= Int32.Parse(ConfigurationManager.AppSettings["logomaxwidth"]))
                {
                    img.Dispose();
                    var i1 = new ImageResizer.ImageJob(savedFileName, Server.MapPath(ImageUrlResolver.ThumbNail()) + guid + hpf.FileName, new ImageResizer.ResizeSettings(
                   "maxwidth=" + ConfigurationManager.AppSettings["logomaxwidth"] + "&maxheight=" + ConfigurationManager.AppSettings["logomaxheight"] + ";mode=stretch")) { CreateParentDirectory = true };
                    i1.Build();
                    _settingsService.UpdateSetting("logo", guid + hpf.FileName);
                    const string error = "New logo updated successfully";
                    var result = Json(error, JsonRequestBehavior.AllowGet);
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
                    const string error = "error:your file is too small !";
                    var result = Json(error, JsonRequestBehavior.AllowGet);
                    return result;
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}