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

        public void removeByBookingId(int bookingId)
        {
            List<BookingFood> bookingFoods = myDb.bookingFoods.Where(x => x.BookingId == bookingId).ToList();
            myDb.bookingFoods.RemoveRange(bookingFoods);
            myDb.SaveChanges();
        }

        public List<BookingFood> getByBooking(int id)
        {
            return myDb.bookingFoods.Where(x => x.BookingId == id).ToList();
        }
    }
}