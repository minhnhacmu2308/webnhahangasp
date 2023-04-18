using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        // GET: Food
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FoodDetail(int id)
        {
            ViewBag.Food = foodRepository.GetFood(id);
            return View();
        }
    }
}