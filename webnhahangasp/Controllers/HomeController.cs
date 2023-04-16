using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webnhahangasp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return View();
        }

        public ActionResult Bookings()
        {
            return View();
        }

        public ActionResult Foods()
        {
            return View();
        }

        public ActionResult Carts()
        {
            return View();
        }

        public ActionResult Profiles()
        {
            return View();
        }

        public ActionResult FoodDetail()
        {
            return View();
        }

        public ActionResult HistoryBook()
        {
            return View();
        }

        public ActionResult HistoryOrder()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult NewDetail()
        {
            return View();
        }

        public ActionResult Payment()
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

        [ChildActionOnly]
        public ActionResult Slide()
        {
            return PartialView();
        }
    }
}