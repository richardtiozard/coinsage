using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoinsAge.Data;
using CoinsAge.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CoinsAge.Controllers;
using CoinsAge.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CoinsAge.Views
{
    public class NewsController : Controller
    {
        private readonly CoinsAge1Context _context;

        private UserManager<CoinsAge1User> _userManager;


        public NewsController(CoinsAge1Context context, UserManager<CoinsAge1User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: News
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Index()
        {

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _context.News
                .Include(x => x.User)
                .Include(y => y.Category)
                .Where(z => z.User.Id == userid).ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult IndexAdmin()
        {
            ViewBag.News = _context.News.OrderByDescending(x => x.PublishDateTime);
            ViewBag.PopularNews = _context.PopularNews.Include(x => x.News).OrderByDescending(x => x.News.PublishDateTime);
            ViewBag.TrendingNews = _context.TrendingNews.Include(x => x.News).OrderByDescending(x => x.News.PublishDateTime);
            return View();
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(p => p.User)
                .Include(q => q.Category)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            ViewBag.News = _context.News
                .Include(p => p.Category)
                .Where(p => p.NewsId != news.NewsId)
                .Where(p => p.Category.CategoryId == news.Category.CategoryId)
                .OrderByDescending(r => r.PublishDateTime)
                .Take(3);

            ViewBag.Categories = _context.Category;

            return View(news);
        }

        // GET: News/Category/5
        public IActionResult Category(int? id)
        {

            ViewBag.News = _context.News
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryId == id)
                .OrderByDescending(q => q.PublishDateTime);

            ViewBag.Category = _context.Category
                .Where(r => r.CategoryId == id);

            ViewBag.Categories = _context.Category;


            return View();
        }

        // GET: News/Create
        [Authorize(Roles = "Writer")]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Category;
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Content,PublishDateTime,Category,ImageFile")] News news)
        {
            if (ModelState.IsValid)
            {
                if (news.ImageFile != null)
                {
                    BlobController x = new BlobController();
                    string imageURL = x.UploadBlob(news.NewsId.ToString(), news.ImageFile);
                    news.ImageURL = imageURL;

                }
                news.PublishDateTime = DateTime.Now;
                news.User = await _userManager.GetUserAsync(User);
                news.Category = _context.Category.Where(x => x.CategoryId == Int64.Parse( Request.Form["Category"])).First();
                _context.Add(news);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            ViewBag.Categories = _context.Category;
            return View(news);
        }

        // GET: News/Edit/5
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            ViewBag.Categories = _context.Category;
            ViewBag.NewsImage = news.ImageURL;
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Title,Content,PublishDateTime,Category,ImageFile")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BlobController x = new BlobController();
                    if (news.ImageFile != null)
                    {
                        string imageURL = x.UploadBlob(news.NewsId.ToString(), news.ImageFile);
                        news.ImageURL = imageURL;

                    }
                    else
                    {
                        news.ImageURL = x.getImageURL(news.NewsId.ToString());
                    }
                    news.PublishDateTime = DateTime.Now;
                    news.Category = _context.Category.Where(x => x.CategoryId == Int64.Parse(Request.Form["Category"])).First();
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Delete/5
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(m => m.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
