using System.Web;
using System.Web.Optimization;

namespace ExamWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/timerjs").Include(
                        "~/Content/countdowntimer/jquery.countdown.js",
                        "~/Content/countdowntimer/jquery.plugin.js"));

            bundles.Add(new StyleBundle("~/bundles/timercss").Include(
                        "~/Content/countdowntimer/jquery.countdown.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Content/BootstrapAdmin/js/jquery.js",
            //          "~/Content/BootstrapAdmin/js/bootstrap.min.js",
            //          "~/Content/BootstrapAdmin/js/plugins/metisMenu/metisMenu.min.js",
            //          "~/Content/BootstrapAdmin/js/sb-admin-2.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/plugins/jquery/jquery-2.1.0.min.js",
                      "~/plugins/jquery-ui/jquery-ui.min.js",
                      "~/plugins/bootstrap/bootstrap.min.js",
                      "~/plugins/justified-gallery/jquery.justifiedgallery.min.js",
                      "~/plugins/tinymce/tinymce.min.js",
                      "~/plugins/tinymce/jquery.tinymce.min.js"
                      ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/BootstrapAdmin/css/bootstrap.css",
            //          "~/Content/BootstrapAdmin/css/site.css",
            //          "~/Content/BootstrapAdmin/css/plugins/metisMenu/metisMenu.min.css",
            //          "~/Content/BootstrapAdmin/css/sb-admin-2.css",
            //          "~/Content/BootstrapAdmin/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/plugins/bootstrap/bootstrap.css",
                      "~/plugins/jquery-ui/jquery-ui.min.css",
                      "~/plugins/fancybox/jquery.fancybox.css",
                      "~/plugins/fullcalendar/fullcalendar.css",
                      "~/plugins/xcharts/xcharts.min.css",
                      "~/plugins/select2/select2.css",
                      "~/Content/style.css"));
        }
    }
}
