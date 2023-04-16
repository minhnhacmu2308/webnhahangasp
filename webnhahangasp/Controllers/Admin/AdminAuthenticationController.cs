using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminAuthenticationController : Controller
    {
        // GET: AdminAuthentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            User user = new User()
            {
                Email = form["email"],
                Password = form["password"]
            };
            if (user.Email == "admin@gmail.com" && user.Password == "123456789")
            {
                    Session.Add("ADMIN", user);
                    return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("ADMIN");
            return Redirect("/AdminHome/Index");
        }
    }
}