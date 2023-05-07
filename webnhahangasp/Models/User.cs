using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }//Giới tính
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}