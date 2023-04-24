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
        BookingRepository bookingRepository = new BookingRepository();
        BookingFoodRepository bookingFoodRepository = new BookingFoodRepository();
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
        public ActionResult Add(Booking booking,List<int> FoodId)
        {
            User user = (User)Session["USER"];
            booking.Date = DateTime.Now.ToString();
            booking.UserID = user.UserId;
            bookingRepository.Add(booking);
            List<BookingFood> bookingFoods = new List<BookingFood>();
            FoodId.ForEach(x => bookingFoods.Add(new BookingFood { FoodId = x, BookingId = booking.BookingId }));
            bookingFoodRepository.Add(bookingFoods);
            return RedirectToAction("Bookings", "Home", new { msg ="1"});
        }

        public ActionResult HistoryBook(int userId)
        {
            ViewBag.HistoryBooking = bookingRepository.bookingsByUserId(userId);
            return View();
        }

    }
}