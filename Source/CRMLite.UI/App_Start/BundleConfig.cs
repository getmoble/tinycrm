using System.Web.Optimization;

namespace CRMLite.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            var jqueryBundle = new StyleBundle("~/Content/BootstrapminCss", "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css").Include(
              "~/Content/css/bootstrap.min.css");
            bundles.Add(jqueryBundle);

            bundles.Add(new StyleBundle("~/Content/BootstrapCommonCss").Include(
          "~/Content/css/bootstrap-datetimepicker.min.css",
          "~/Content/css/jquery-ui-1.10.4.min.css"
            ));

            bundles.Add(new StyleBundle("~/Content/FontAndIconCommonCss").Include(
          "~/Content/css/font-awesome.min.css"
            ));

            var googleapis = new StyleBundle("~/Content/Googleapis", "http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,400,300,700,800");
            bundles.Add(googleapis);

            bundles.Add(new StyleBundle("~/Content/CustomCommonCss").Include(
                "~/Content/css/propznet-style.css",
                "~/Content/css/menu-bar.css",
                  "~/Content/css/style.css",
                  "~/Content/css/style-responsive.css",
                  "~/Content/css/bootstrap_calendar.css",
                  "~/Content/css/widgets.css",
                  "~/Content/css/fullcalendar.min.css",
                  "~/Content/css/fileinput.css",
                  "~/Content/css/toastr.min.css"

               ));

            var jqueryJsBundle = new ScriptBundle("~/Content/Js/JqueryminJs", "http://cdn.jsdelivr.net/jquery/3.0.0-alpha1/jquery.min.js").Include(
            "~/Content/js/jquery-2.1.1.min.js");
            bundles.Add(jqueryJsBundle);

            var bootstrapJsBundle = new ScriptBundle("~/Content/Js/BootstrapminJs", "http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js").Include(
            "~/Content/js/bootstrap.min.js");
            bundles.Add(bootstrapJsBundle);


            bundles.Add(new ScriptBundle("~/Content/js/JqueryScripts").Include(
                               "~/Content/js/jquery-ui.js",
                                "~/Content/js/jquery.ui.widget.js",
                                "~/Content/js/jquery.fileupload.js",
                                "~/Content/js/jquery.dataTables.min.js",
                                "~/Content/js/jquery.knob.js",
                                "~/Content/js/jquery.sparkline.js",
                                "~/Content/js/jquery.rateit.min.js",
                                "~/Content/js/jquery.customSelect.min.js",
                                "~/Content/js/jquery.autosize.min.js",
                                "~/Content/js/jquery.placeholder.min.js",
                                "~/Content/js/jquery.slimscroll.min.js",
                                "~/Content/js/jquery.nicescroll.js",
                                "~/Content/js/jquery.scrollTo.min.js"
                               
                       ));
            var blueimpfileuploadJs = new ScriptBundle("~/Content/Js/BlueimpfileuploadJs",
                "https://cdnjs.cloudflare.com/ajax/libs/blueimp-file-upload/9.5.7/jquery.iframe-transport.js");
            bundles.Add(blueimpfileuploadJs);

            bundles.Add(new ScriptBundle("~/Content/js/CustomCommonJs").Include(
                                "~/Content/js/chartinator.js",
                                "~/Content/js/fileinput.js",
                                "~/Content/js/bootbox.min.js",
                                "~/Content/js/countto.js",
                                "~/Content/js/classie.js",
                                "~/Content/js/owl.carousel.js",
                                "~/Content/js/scripts.js",
                                "~/Content/js/demo.js",
                                "~/Content/js/uisearch.js",
                                "~/Content/js/bootstrap_calendar.js",
                                "~/Content/js/moment.min.js",
                                "~/Content/js/fullcalendar.min.js",
                                 "~/Content/js/jquery.dataTables.min.js",
                                "~/Content/js/dataTables.bootstrap.js",
                                "~/Content/js/bootstrap-datetimepicker.min.js",
                                "~/Content/js/toastr.min.js"
                        ));

            var knockoutJs = new ScriptBundle("~/Content/Js/KnockoutJS",
             "https://cdn.jsdelivr.net/knockout/3.3.0/knockout.js").Include(
                             "~/Content/js/knockout-3.2.0.js");
            bundles.Add(knockoutJs);

            bundles.Add(new ScriptBundle("~/Content/js/CommonKnockoutJs").Include(
                "~/Content/js/knockout.validation.js",
                "~/Content/js/knockout.custom.js",
                "~/App/utils.js",
                "~/Content/js/urls.js"
                ));
        }
    }
}

