using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        OrderRepository orderRepository = new OrderRepository();
        // GET: AdminHome
        public ActionResult Index()
        {
            User user = (User)Session["ADMIN"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminAuthentication");
            }
            else
            {
                var list = orderRepository.getAll();
                ViewBag.Count = list.Any() ? list.Count : 0;
                var sum = orderRepository.sum();
                ViewBag.Sum = sum;
                return View();
            }

        }
    }
}