using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class OrderDetailRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            myDb.orderDetails.Add(orderDetail);
            myDb.SaveChanges();
        }
    }
}