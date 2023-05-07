using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminOrderController : Controller
    {
        OrderRepository orderRepository = new OrderRepository();
        // GET: AdminOrder
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = orderRepository.getAll();
            return View();
        }

        public ActionResult Update(Order order)
        {
            orderRepository.update(order);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}