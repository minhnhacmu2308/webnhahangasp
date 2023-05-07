using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers.Admin
{
    public class AdminTypeFoodController : Controller
    {
        TypeFoodRepository typeFoodRepository = new TypeFoodRepository();
        // GET: AdminTypeFood
        public ActionResult Index()
        {
            ViewBag.List = typeFoodRepository.GetAll();
            return View();
        }
    }
}