using CoinsAge.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class News
    {
        [Key]
        public int NewsId { set; get; }

        [Required]
        public string Title { set; get; }

        [Required]
        public string Content { set; get; }

        [Required]
        public DateTime PublishDateTime { set; get; }

        //Foreign Key
        public CoinsAge1User User { get; set; }
        public Category Category { get; set; }

        public ICollection<TrendingNews> TrendingNews { get; set; }
        public ICollection<PopularNews> PopularNews { get; set; }
    }
}
