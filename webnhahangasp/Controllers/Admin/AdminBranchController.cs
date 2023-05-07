using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Models;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminBranchController : Controller
    {
        BranchRepository typeDao = new BranchRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.GetBranches();
            return View();
        }
        public ActionResult Add(Branch branch)
        {
            typeDao.add(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(Branch branch)
        {
            typeDao.update(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Branch branch)
        {
            var check = typeDao.getBookingBranch(branch.BranchId);
            if (check.Count == 0)
            {
                typeDao.delete(branch.BranchId);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}