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
    }
}