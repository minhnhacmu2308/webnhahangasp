using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminAuthenticationController : Controller
    {
        UserRepository userDao = new UserRepository();
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
            string passwordMd5 = userDao.md5(form["password"]);
            User userInformation = userDao.checkLogin(user.Email, passwordMd5);
            if (userInformation != null && userInformation.RoleId != 3)
            {
                    Session.Add("ADMIN", userInformation);
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