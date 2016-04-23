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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult CMSPage(string name)
        {
            return View();
        }

        public ActionResult Contact(string param1, string param2)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.test = DAL.TestConnection();

            return View();
        }

        private ViewEngineResult ReturnView(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return ViewEngines.Engines.FindView(ControllerContext, name, null);
            else
                return null;
            
        }

        public ActionResult NoJoy()
        {
            return View();
        }


        private string GetFirstSegment(string fullString, char delimiter)
        {
            if (!string.IsNullOrEmpty(fullString))
            {
                var temp = fullString.Split(delimiter);
                    var retval = temp[0];
                    return retval;
            }
            else return null;
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
        public ActionResult Router(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var firstSegment = GetFirstSegment(url, '/');

                //this is a page that is included in our CMS (page viewable via the DB)
                CMSPage cmsPage = new CMSPage();
                cmsPage = cmsPage.GetPage(firstSegment);
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