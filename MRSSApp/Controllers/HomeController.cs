using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSSApp.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Specialities()
        {
            ViewBag.Message = "Your Specialities page.";

            return View();
        }

        public ActionResult PatientCare()
        {
            ViewBag.Message = "Your Patient Care page.";

            return View();
        }
    }
}