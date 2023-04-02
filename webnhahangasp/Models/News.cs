using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webnhahangasp.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public string Content { get; set; }

        public string Created_at { get; set; }
        public int Created_by { get; set; }
    }
}