using LifeLine.Core.Models;
using LifeLine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeLine.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //Write error logging code            
            var exceptionDetail = new ExceptionModel
            {
                Controller = (string)filterContext.RouteData.Values["controller"],
                View = (string)filterContext.RouteData.Values["action"],
                StackTrace = filterContext.Exception.StackTrace,
                Source = filterContext.Exception.Source
            };

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(filterContext.Controller.ViewData)
                {
                    Model = exceptionDetail
                }
            };

        }
    }
}