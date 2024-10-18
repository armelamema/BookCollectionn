using System.Diagnostics;
using System.Web.Optimization;

namespace BookCollection
{
    public class BundleConfig
    {
        private const string VirtualPath = "~/Scripts/bootstrap.js";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   VirtualPath));

            // Log the bundle registration
            Debug.WriteLine("Bootstrap bundle registered with path: " + VirtualPath);

            // Modernizr
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            // CSS bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
