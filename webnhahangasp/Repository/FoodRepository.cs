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
            return myDb.foods.Where(x => x.TypeFoodId == 1).OrderByDescending(u => u.FoodId).ToList().
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

        public List<Food> getAll()
        {
            return myDb.foods.OrderByDescending(x => x.FoodId).ToList();
        }

        public void add(Food branch)
        {
            myDb.foods.Add(branch);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.foods.FirstOrDefault(x => x.FoodId == id);
            myDb.foods.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Food branch)
        {
            var obj = myDb.foods.FirstOrDefault(x => x.FoodId == branch.FoodId);
            obj.Name = branch.Name;
            obj.Image = branch.Image;
            obj.Price = branch.Price;
            obj.Description = branch.Description;
            obj.TypeFoodId = branch.TypeFoodId; 
            myDb.SaveChanges();
        }

        public List<Menu> getMenuByFood(int id)
        {
            return myDb.menus.Where(x => x.FoodId == id).ToList();
        }

        public List<OrderDetail> getODByFood(int id)
        {
            return myDb.orderDetails.Where(x => x.FoodId == id).ToList();
        }

        public List<BookingFood> getBFbyFood(int id)
        {
            return myDb.bookingFoods.Where(x => x.FoodId == id).ToList();
        }
    }
}