using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminMenuController : Controller
    {
        MenuRepository typeDao = new MenuRepository();
        FoodRepository foodDao = new FoodRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.getAll();
            ViewBag.listType = foodDao.getAll();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Menu branch)
        {
            typeDao.AddMenu(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Menu branch)
        {
            typeDao.update(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Menu branch)
        {
            typeDao.delete(branch.MenuId);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}