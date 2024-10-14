using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using BookCollectionn;

namespace BookCollection
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Fixing the Profile property
        protected System.Web.Profile.DefaultProfile Profile
        {
            get
            {
                // Correct usage of HttpContext
                return (System.Web.Profile.DefaultProfile)(HttpContext.Current.Profile);
            }
        }
    }
}
