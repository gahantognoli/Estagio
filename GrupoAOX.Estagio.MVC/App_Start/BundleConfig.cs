using System.Web;
using System.Web.Optimization;

namespace GrupoAOX.Estagio.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                      "~/Scripts/Global.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Login").Include(
                "~/Content/bootstrap.css",
                "~/Content/login.css"
            ));

            bundles.Add(new StyleBundle("~/Content/icheck").Include(
                      "~/Content/icheck-bootstrap.min.css"));

            #region Meus bundles
            bundles.Add(new ScriptBundle("~/bundles/Usuarios").Include(
                     "~/Scripts/Usuarios/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/Romaneio").Include(
                     "~/Scripts/Romaneio/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/OrdemExpedicao").Include(
                     "~/Scripts/OrdemExpedicao/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/DescartarEtiqueta").Include(
                     "~/Scripts/DescartarEtiqueta/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/RelatorioRomaneio").Include(
                     "~/Scripts/ImpressaoRomaneio/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/ImpressaoOrdemExpedicao").Include(
                     "~/Scripts/ImpressaoOrdemExpedicao/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/EtiquetasGeradas").Include(
                     "~/Scripts/EtiquetasGeradas/script.js",
                     "~/Scripts/jquery.mask.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/MovimentosGerados").Include(
                     "~/Scripts/MovimentosGerados/script.js",
                     "~/Scripts/jquery.mask.min.js"));

            #endregion

        }
    }
}
