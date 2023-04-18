using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class BookingFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingFoodId { get; set; }

        public int BookingId { get; set; }

        public int FoodId { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Food Food { get; set; }
    }
}