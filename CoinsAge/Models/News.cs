using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class News
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Content { set; get; }

        public DateTime PublishDateTime { set; get; }

        
    }
}
