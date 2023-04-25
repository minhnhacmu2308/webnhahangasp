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
        public void AddMenu(Menu menu)
        {
            menu.Date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +DateTime.Now.Year;
            myDb.menus.Add(menu);
            myDb.SaveChanges();
        }

/*        public string GetSessionByTime(TimeSpan time)
        {
            *//*TimeSpan timeMorning = TimeSpan.Parse("08:00");*//*
            TimeSpan timeNoon = TimeSpan.Parse("10:00");
            TimeSpan timeEvening = TimeSpan.Parse("17:00");
            if (TimeSpan.Compare(time, timeNoon) == -1)
            {
                return "Sáng";
            }else if (TimeSpan.Compare(time, timeEvening) == -1)
            {
                return "Trưa";
            }
            else
            {
                return "Tối";
            }
        }
*/
        public string GetSessionByTime(TimeSpan time)
        {
            string session = "";

            if (time.Hours >= 0 && time.Hours < 12)
            {
                session = "Sáng";
            }
            else if (time.Hours >= 12 && time.Hours < 18)
            {
                session = "Trưa";
            }
            else
            {
                session = "Tối";
            }

            return session;
        }

        public List<Menu> GetMenusBySession(string session)
        {        
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            return myDb.menus.Where(x => x.Session.Equals(session) && x.Date.Equals(date)).ToList();
        }

    }
}