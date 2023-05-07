using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminCustomerController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: AdminCustomer
        public ActionResult Index()
        {
            ViewBag.List = userRepository.GetCustomer();
            return View();
        }
    }
}