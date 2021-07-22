using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class PopularNews
    {
        [Key]
        public int PopularNewsId { set; get; }

        //Foreign Key reference to News
        public News News { get; set; }
    }
}
