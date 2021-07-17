using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class Newsletter
    {
        [Key]
        public int NewsletterId { set; get; }

        [Required]
        public string Email { set; get; }
    }
}
