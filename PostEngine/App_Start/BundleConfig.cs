using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PostEngine.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                         "~/Scripts/jquery-3.0.0.min.js",
                         "~/Scripts/popper.js",
                         "~/Scripts/bootstrap.min.js",
                         "~/Scripts/custom/jquery/Inicialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                         "~/Scripts/angular.min.js",
                         "~/Scripts/custom/app.js",
                         "~/Scripts/custom/services/root.service.js",
                         "~/Scripts/custom/services/blog.service.js",
                         "~/Scripts/custom/services/user.service.js",
                         "~/Scripts/custom/services/app.service.js",
                         "~/Scripts/custom/controllers/util.controller.js",
                         "~/Scripts/custom/controllers/blog.controller.js",
                         "~/Scripts/custom/controllers/user.controller.js"));

            // Code removed for clarity.
            BundleTable.EnableOptimizations = false;            
        }
    }
}