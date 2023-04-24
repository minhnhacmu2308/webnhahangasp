﻿using System;
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
    }
}