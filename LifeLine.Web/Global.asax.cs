using LifeLine.Core.Models;
using LifeLine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LifeLine.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["BloodDonorContext"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Start SqlDependency with application initialization
            SqlDependency.Start(_connString);

            BloodDonorInitalizeDb db = new BloodDonorInitalizeDb();
            System.Data.Entity.Database.SetInitializer(db);
        }
        /// <summary>
        /// All the controls will be attributed with HandleError
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var raisedException = Server.GetLastError();

            // Process exception
            //Write error logging code            
            var exceptionDetail = new ExceptionModel
            {
                Controller = "UNKNOWN",
                View = "UNKNOWN",
                StackTrace = raisedException.StackTrace,
                Source = raisedException.Source
            };
            //write to the log

            //redirect to the error page
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(_connString);
        }

    }
}

