using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminBookingController : Controller
    {
        BookingRepository bookingRepository = new BookingRepository();
        // GET: AdminBooking
        public ActionResult Index()
        {
            ViewBag.List = bookingRepository.getAll();
            return View();
        }
    }
}