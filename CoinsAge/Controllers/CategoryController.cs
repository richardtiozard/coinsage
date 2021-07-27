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
    public class CategoryController : Controller
    {
        private readonly CoinsAge1Context _context;

        public CategoryController(CoinsAge1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Category = _context.Category.OrderBy(x => x.CategoryId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(string categoryname)
        {
            Category category = _context.Category.Where(x => x.CategoryName == categoryname).FirstOrDefault();
            if (category != null)
            {
                ViewBag.Message = "Category exists already";
            }
            else
            {
                Category newcategory = new Category(categoryname);
                _context.Add(newcategory);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Category");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int categoryid)
        {

            foreach (var news in _context.News.Where(x => x.Category.CategoryId == categoryid))
            {
                foreach (var popnews in _context.PopularNews.Where(x => x.News == news))
                {
                    _context.PopularNews.Remove(popnews);
                }
                foreach (var trendnews in _context.TrendingNews.Where(x => x.News == news))
                {
                    _context.TrendingNews.Remove(trendnews);
                }
                _context.News.Remove(news);
            }

            var category = _context.Category.Where(x => x.CategoryId == categoryid).FirstOrDefault();
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return Redirect("/Category");
        }
    }
}