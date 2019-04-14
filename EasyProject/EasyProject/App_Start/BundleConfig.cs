using System.Web;
using System.Web.Optimization;

namespace EasyProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/owl.carousel.min.js",
                         "~/Scripts/jquery.nicescroll.min.js",
                         "~/Scripts/isotope.pkgd.min.js",
                         "~/Scripts/imagesloaded.pkgd.min.js",
                         "~/Scripts/circle-progress.min.js",
                         "~/Scripts/main.js",
                         "~/Scripts/alertify.min.js",
                         "~/Scripts/Core/Core.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                                       "~/Scripts/angular.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/owl.carousel.min.css",
                      "~/Content/animate.css",
                      "~/Content/alertify.min.css",
                      "~/Content/site.css"));
        }
    }
}
