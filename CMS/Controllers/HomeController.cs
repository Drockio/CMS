using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //RouteConfig will send us to the declared action if 

            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult CMSPage(string name)
        {
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

        public string GetPageContent(string pageName)
        {
            //TODO:  Get this from the DB
            return "<p>A whole bunch of conent for: " + pageName + "</p>";
        }

        public ActionResult NoJoy()
        {
            return View();
        }


        /// <summary>
        /// Method determines whether "pageName" is a "real" view and controller entry, or a virtual page.
        /// If it is a "real" view, the real view is called.
        /// Else a page entry is searched for in the DB.  If it isn't found, display a groovy 404 page.
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public ActionResult Router(string pageName, string param1 = null, string param2 = null)
        {
            var selectedView = ReturnView(pageName);

            //views and controller entry exist for this view, call it!
            if (selectedView.View != null)
            {
                return View(selectedView.View);
            }
            //views and controller entry do not exist for this view, try to find it's content in the DB
            else
            {
                //this is a page that is included in our CMS (page viewable via the DB)
                CMSPage cmsPage = new CMSPage();
                cmsPage = cmsPage.GetPage(pageName);
                if (cmsPage != null)
                {
                    return View("CMSPage", cmsPage);
                }
                else
                    return View("NoJoy");
            }
        }
    }
}