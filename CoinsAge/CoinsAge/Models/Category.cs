using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }

        [Required]
        public string CategoryName { set; get; }

        public ICollection<News> News { get; set; }
    }
}
