using System.Web.Optimization;

namespace LOG.PropznetCRM.Data.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/CustomCommonCss").Include(
                   "~/Content/css/bootstrap.min.css",
                  // "~/Content/css/font-awesome.min.css",
                    "~/Content/css/Site.css",
                //"~/Content/css/jquery-ui.css",
                //"~//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css",

                    "~/Content/css/dataTables.bootstrap.css",
                    "~/Content/css/jquery.dataTables.min.css"
               ));
            bundles.Add(new ScriptBundle("~/Content/js/AllScripts").Include(
                                "~/Content/js/jquery-2.1.1.min.js",
                                 "~/Content/js/jquery-ui.js",
                                 "~/Content/js/jquery.dataTables.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Content/js/Allknockout").Include(
                "~/Content/js/knockout-3.2.0.js",//cdn.jsdelivr.net/knockout/3.3.0/knockout.js
                "~/Content/js/knockout.validation.js",
                "~/Content/js/knockout.custom.js",
                "~/Content/js/bootbox.min.js",
                "~/Content/js/dataTables.bootstrap.js",
                "~/Content/js/jquery.fileupload.js",
                //"~//code.jquery.com/jquery-1.10.2.js",
                "~/Content/js/jquery.ui.widget.js",
                "~/App/utils.js",
                "~/App/viewModels.js",
                "~/App/models.js"
                ));
        }
    }
}

