using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class OrderRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public void AddOrder(Order order)
        {
            myDb.orders.Add(order);
            myDb.SaveChanges();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return myDb.orders.Where(x => x.UserId == userId).OrderByDescending(x=>x.OrderId).ToList();
        }

        public List<Order> getAll()
        {
            return myDb.orders.OrderByDescending(x => x.OrderId).ToList();
        }

        public int sum()
        {
            return myDb.orders.Sum(x => x.Amount);
        }

        public void update(Order order)
        {
            var obj = myDb.orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            obj.Status = order.Status;
            if(order.Status == 3)
            {
                obj.IsPayment = 1;
            }
            myDb.SaveChanges();
        }
    }
}