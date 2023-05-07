using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminFoodController : Controller
    {
        FoodRepository typeDao = new FoodRepository();
        TypeFoodRepository tpDao = new TypeFoodRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.getAll();
            ViewBag.listType = tpDao.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Food branch)
        {
            var file = Request.Files["file"];
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            branch.Image = reName;
            branch.Status = 1;
            typeDao.add(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Food branch)
        {
            string reName = "";
            var objCourse = typeDao.GetFood(branch.FoodId);
            var file = Request.Files["file"];
            if (file.FileName == "")
            {
                reName = objCourse.Image;
            }
            else
            {
                reName = DateTime.Now.Ticks.ToString() + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            }
            branch.Image = reName;
            typeDao.update(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Food branch)
        {
            var menu = typeDao.getMenuByFood(branch.FoodId);
            var od = typeDao.getODByFood(branch.FoodId);
            var bk = typeDao.getBFbyFood(branch.FoodId);
            if (menu.Count == 0 && od.Count == 0 && bk.Count == 0)
            {
                typeDao.delete(branch.FoodId);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}