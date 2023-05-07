using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminNewsController : Controller
    {
        NewsRepository typeDao = new NewsRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.getAll();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(News branch)
        {
            var file = Request.Files["file"];
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            branch.Image = reName;
            branch.Created_at = DateTime.Now.ToString();
            typeDao.add(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(News branch)
        {
            string reName = "";
            var objCourse = typeDao.GetNew(branch.NewsId);
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

        public ActionResult Delete(News branch)
        {
            typeDao.delete(branch.NewsId);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}