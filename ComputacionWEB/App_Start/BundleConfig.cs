using System.Web;
using System.Web.Optimization;

namespace ComputacionWEB
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Externos/Jquery/jquery-{version}.js"
                        , "~/Scripts/Externos/Knockout/knockout-3.5.1.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Externos/Jquery/jquery.validate*"
                        ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/Externos/Bootstrap/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/bootstrapJS").Include(
                        "~/Scripts/Externos/Popper/popper.min.js",
                       "~/Scripts/Externos/Bootstrap/bootstrap.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Externos/Bootstrsap/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
