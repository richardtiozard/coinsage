using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class TrendingNews
    {
        [Key]
        public int TrendingNewsId { set; get; }

        //Foreign Key reference to News
        public News News { get; set; }

        public TrendingNews()
        {
        }
        public TrendingNews(News news)
        {
            this.News = news;
        }
    }
}
