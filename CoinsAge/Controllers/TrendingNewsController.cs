using CoinsAge.Data;
using CoinsAge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class TrendingNewsController : Controller
    {
        private readonly CoinsAge1Context _context;

        public TrendingNewsController(CoinsAge1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int newsid)
        {
            News news = _context.News.Find(newsid);
            TrendingNews trendingnews = _context.TrendingNews.Where(x => x.News == news).FirstOrDefault();
            if (trendingnews != null)
            {
                ViewBag.Message = "News exists already";
            }
            else
            {
                TrendingNews trendnews = new TrendingNews(news);
                _context.Add(trendnews);
                await _context.SaveChangesAsync();
            }

            return Redirect("/News/IndexAdmin");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int newsid)
        {
            var trendnews = _context.TrendingNews.Where(x => x.News.NewsId == newsid).FirstOrDefault();
            _context.TrendingNews.Remove(trendnews);
            await _context.SaveChangesAsync();

            return Redirect("/News/IndexAdmin");
        }
    }
}
