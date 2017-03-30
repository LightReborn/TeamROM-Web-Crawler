using System.Web.Optimization;

namespace WebCrawler.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
#if !DEBUG
            bundles.UseCdn = true;
            BundleTable.EnableOptimizations = true;
#endif

            bundles.Add(new StyleBundle("~/bundles/bootstrapcss", "//maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css")
                .Include("~/Content/bootstrap/bootstrap.css")
                );

            bundles.Add(new StyleBundle("~/bundles/commoncss")
                .Include("~/Content/styles.css")
                );

            bundles.Add(new StyleBundle("~/bundles/permanentmarker", "//fonts.googleapis.com/css?family=Permanent+Marker")
                .Include("~/Content/Fonts/permanentmarker.css")
                );

            bundles.Add(new StyleBundle("~/bundles/alegreya", "//fonts.googleapis.com/css?family=Alegreya")
                .Include("~/Content/Fonts/alegreya.css")
                );


            bundles.Add(new ScriptBundle("~/bundles/jqueryjs", "//ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js")
                .Include("~/Scripts/jquery-3.1.0.min.js")
                );

          
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs", "//maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js")
                .Include("~/Scripts/bootstrap.js")
                );
        }
    }
}