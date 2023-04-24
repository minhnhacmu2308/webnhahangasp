using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webnhahangasp.Repository;

namespace webnhahangasp.Controllers
{
    public class NewController : Controller
    {
        NewsRepository newsRepository = new NewsRepository();
        // GET: New
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewDetail(int id)
        {
            ViewBag.New = newsRepository.GetNew(id);
            return View();
        }
    }
}