using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public int UserID { get; set; }

        public int BranchId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string Note { get; set; }

        public int NumberPeople { get; set; }

        public int Status { get; set; }

        public virtual User User { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual ICollection<BookingFood> BookingFoods { get; set; }
    }
}