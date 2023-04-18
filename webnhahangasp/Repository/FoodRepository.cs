using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class FoodRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();
        public List<Food> GetFoods(int page, int pagesize)
        {
            return myDb.foods.OrderByDescending(u => u.FoodId).ToList().
                Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }


        public int getNumberFood()
        {
            int total = myDb.foods.Where(p => p.Status == 1).ToList().Count;
            int count = 0;
            count = total / 8;
            if (total % 8 != 0)
            {
                count++;
            }
            return count;
        }

        public Food GetFood(int id)
        {
            return myDb.foods.FirstOrDefault(x => x.FoodId == id);
        }
    }
}