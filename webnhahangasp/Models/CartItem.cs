using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}