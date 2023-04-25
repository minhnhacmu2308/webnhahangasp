using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class HomeController : Controller
    {
        NewsRepository newsRepository = new NewsRepository();
        FoodRepository foodRepository = new FoodRepository();
        MenuRepository menuRepository = new MenuRepository();
        BranchRepositpry branchRepository = new BranchRepositpry();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.ListEvening = menuRepository.GetMenusBySession("Tối");
            ViewBag.ListNoon = menuRepository.GetMenusBySession("Trưa");
            ViewBag.ListMorning = menuRepository.GetMenusBySession("Sáng");
            ViewBag.Booking = branchRepository.GetBranches();
            return View();
        }

        public ActionResult News(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.List = newsRepository.GetNews(page, 4);
            ViewBag.tag = page;
            ViewBag.pageSize = newsRepository.getNumberNews();
            return View();
        }

        public ActionResult Menus()
        {
            ViewBag.ListEvening = menuRepository.GetMenusBySession("Tối");
            ViewBag.ListNoon = menuRepository.GetMenusBySession("Trưa");
            ViewBag.ListMorning = menuRepository.GetMenusBySession("Sáng");
            return View();
        }

        public ActionResult Bookings(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.Booking = branchRepository.GetBranches();
            return View();
        }

        public ActionResult Foods(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.List = foodRepository.GetFoods(page, 8);
            ViewBag.tag = page;
            ViewBag.pageSize = foodRepository.getNumberFood();
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