using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace ITCR.Application
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Injector.Current.Register();
        }

        void Application_End(object sender, EventArgs e)
        {
            Injector.Current.Dispose();
        }
    }
}