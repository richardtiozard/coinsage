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
    public class PopularNewsController : Controller
    {
        private readonly CoinsAge1Context _context;

        public PopularNewsController(CoinsAge1Context context)
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
            PopularNews popularnews = _context.PopularNews.Where(x => x.News == news).FirstOrDefault();
            if (popularnews != null)
            {
                ViewBag.Message = "Exist";
            }
            else
            { 
                PopularNews popnews = new PopularNews(news);
                _context.Add(popnews);
                await _context.SaveChangesAsync();
            }

            return Redirect("/News/IndexAdmin");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int newsid)
        {
            var popnews = _context.PopularNews.Where(x => x.News.NewsId == newsid).FirstOrDefault();
            _context.PopularNews.Remove(popnews);
            await _context.SaveChangesAsync();

            return Redirect("/News/IndexAdmin");

        }
    }
}
