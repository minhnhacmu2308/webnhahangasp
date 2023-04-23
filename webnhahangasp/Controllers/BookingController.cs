using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class BookingController : Controller
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();
        MenuRepository menuRepository = new MenuRepository();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMenuByTime(string time)
        {
            string session = menuRepository.GetSessionByTime(TimeSpan.Parse(time));
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            var list = myDb.menus.Where(x => x.Session.Equals(session) && x.Date.Equals(date)).Select(x=>new { 
                MenuId = x.MenuId,
                Date = x.Date,
                Session = x.Session,
                FoodId = x.Food.FoodId,
                FoodName = x.Food.Name,
                FoodPrice = x.Food.Price 
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
                        
        [HttpPost] 
        public ActionResult Add(Booking booking)
        {
            TimeSpan time = TimeSpan.Parse(booking.Time);
            string session = menuRepository.GetSessionByTime(time);
            return View();
        }
    }
}