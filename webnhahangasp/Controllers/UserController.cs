using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profiles(string msg)
        {
            ViewBag.Msg = msg;
            User user = (User)Session["USER"];
            ViewBag.User = userRepository.getUserByEmail(user.Email);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(User user)
        {
            userRepository.Update(user);
            return RedirectToAction("Profiles", new { msg = "1" });
        }
    }
}