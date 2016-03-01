using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeLine.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Welcome")]
    public class HomeController : BaseController
    {
        //[Route("~/")] //Specifies that this is the default action for the entire application
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SiteActivity()
        {
            return View();
        }
       
    }
}