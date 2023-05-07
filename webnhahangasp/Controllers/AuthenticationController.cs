using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class AuthenticationController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: Authentication
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool checkEmailExist = userRepository.checkExistEmail(user.Email, user.Phone);
            if (checkEmailExist)
            {

                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                user.RoleId = 3;
                user.Status = 1;
                user.Password = userRepository.md5(user.Password);

                userRepository.Add(user);

                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            string passwordMd5 = userRepository.md5(user.Password);
            User userInformation = userRepository.checkLogin(user.Email, passwordMd5);
            if (userInformation != null)
            {
                Session.Add("USER", userInformation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/Home/Index");
        }
    }
}