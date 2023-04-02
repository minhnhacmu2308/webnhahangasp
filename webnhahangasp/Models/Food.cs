using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
        public int TypeFoodId { get; set; }
    }
}