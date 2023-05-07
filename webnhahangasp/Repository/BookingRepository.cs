using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class BookingRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public void Add(Booking booking)
        {
            myDb.bookings.Add(booking);
            myDb.SaveChanges();
        }

        public List<Booking> bookingsByUserId(int userId)
        {
            return myDb.bookings.Where(x => x.UserID == userId).ToList();
        }

        public List<Booking> getAll()
        {
            return myDb.bookings.OrderByDescending(x => x.BookingId ).ToList();
        }

        public void cancelBooking(int BookingId)
        {
            Booking booking = myDb.bookings.FirstOrDefault(x => x.BookingId == BookingId);
            myDb.bookings.Remove(booking);
            myDb.SaveChanges();
        }
    }
}