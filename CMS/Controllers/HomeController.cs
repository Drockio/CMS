using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //RouteConfig will send us to the declared action if 

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

        private ViewEngineResult ReturnView(string name)
        {
            return ViewEngines.Engines.FindView(ControllerContext, name, null);
            
        }

        public ActionResult Router(string tierOne, string tierTwo = null, string tierThree = null)
        {
            var view = ReturnView(tierOne);
            if (view.View != null)
            {
                //this is a view that is DECLARED.  It has an ActionResult in this controller.
                //later we will put a case statement here that calls the appropriate ActionResult
                return View(view);
            }
            else
            {
                //this is a page that is included in our CMS (page viewable via the DB)
                //in this function we will query the DB and get the content for the page.  We will route it through a default view.
                return View("index");
            }
        }
    }
}