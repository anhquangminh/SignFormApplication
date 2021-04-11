using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace New_Esign
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Default display language
            string languageId = Ultils.GetCookie("language");
            if (string.IsNullOrWhiteSpace(languageId)) languageId = LanguageHelper.languageEN;
            LanguageHelper.languageId = LanguageHelper.languageEN;
            //session timeout            
            if ( Context.Session != null)
            {
                Session.Timeout = 120;
            }
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
