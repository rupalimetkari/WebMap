using System.Web;
using System.Web.Optimization;

namespace WebMap
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new Bundle("~/bundles/indexcss").Include(
                      "~/Content/index.css"
                ));
            bundles.Add(new Bundle("~/bundles/mapjs").Include(
                      "~/Scripts/map.js"
                ));
            bundles.Add(new Bundle("~/bundles/chartcss").Include(
                        "~/Content/chart.css"
                ));
            bundles.Add(new Bundle("~/bundles/chartjs").Include(
                        "~/Scripts/highstock.js",
                        "~/Scripts/series-label.js",
                        "~/Scripts/exporting.js",
                        "~/Scripts/export-data.js",
                        "~/Scripts/accessibility.js",
                        "~/Scripts/chart.js"
                 ));

            bundles.Add(new Bundle("~/bundles/DataTablescss").Include(
                     "~/Content/dataTables.min.css"
               ));
            bundles.Add(new Bundle("~/bundles/DataTablesjs").Include(
                      "~/Scripts/dataTables.min.js"
                ));
        }
    }
}
