using System.Web.Optimization;

namespace Web.App.App_Start
{
    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.UseCdn = true;   //enable CDN support

            //add link to jquery on the CDN
            //var jqueryCdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js";

            //bundles.Add(new ScriptBundle("~/bundles/jquery",
            //            jqueryCdnPath).Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Code removed for clarity.

            bundles.Add(new StyleBundle("~/bundles/bootstrap")
                .Include("~/Content/bootstrap.min.css"));
        }
    }
}