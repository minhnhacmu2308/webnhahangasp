using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class BookingFoodRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();
        
        public void Add(List<BookingFood> bookingFoods)
        {
            myDb.bookingFoods.AddRange(bookingFoods);
            myDb.SaveChanges();
        }
    }
}