using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class MenuRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();
       
        public List<Menu> GetMenusEvening()
        {
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            return myDb.menus.Where(x => x.Session.Equals("Tối") && x.Date.Equals(date)).ToList();
        }

        public List<Menu> GetMenusMorning()
        {
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            return myDb.menus.Where(x => x.Session.Equals("Sáng") && x.Date.Equals(date)).ToList();
        }

        public List<Menu> GetMenusNoon()
        {
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            return myDb.menus.Where(x => x.Session.Equals("Tối") && x.Date.Equals(date)).ToList();
        }

        public void AddMenu(Menu menu)
        {
            menu.Date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +DateTime.Now.Year;
            myDb.menus.Add(menu);
            myDb.SaveChanges();
        }

    }
}