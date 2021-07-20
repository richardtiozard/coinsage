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

namespace CoinsAge.Views
{
    public class NewsController : Controller
    {
        private readonly CoinsAge1Context _context;

        public NewsController(CoinsAge1Context context)
        {
            _context = context;
        }

        private CloudBlobContainer getBlobStorageInformation()
        {
            //step 1: read json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();
            //to get key access
            //once link, time to read the content to get the connectionstring
            CloudStorageAccount objectaccount = CloudStorageAccount.Parse(configure["ConnectionStrings:BlobStorageConnection"]);
            CloudBlobClient blobclient = objectaccount.CreateCloudBlobClient();
            //step 2: how to create a new container in the blob storage account.
            CloudBlobContainer container = blobclient.GetContainerReference("coinsageblobcontainer");
            return container;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
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

            List<string> listblobs = new List<string>();
            String blobs = "";

            CloudBlobContainer container = getBlobStorageInformation();
            BlobResultSegment result = container.ListBlobsSegmentedAsync(null).Result;
            foreach (IListBlobItem item in result.Results)
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    listblobs.Add(blob.Name + "#" + blob.Uri.ToString());

                    String[] blobid = blob.Name.Split(".");
                    if (Int64.Parse(blobid[0]) == id)
                    {
                        blobs = blob.Uri.ToString();
                    }
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory blob = (CloudBlobDirectory)item;
                    listblobs.Add(blob.Uri.ToString());
                    blobs = blob.Uri.ToString();
                }
            }
            ViewBag.NewsImage = blobs;
            ViewBag.NewsImageList = listblobs;

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

            CloudBlobContainer container = getBlobStorageInformation();
            List<string> blobs = new List<string>();
            BlobResultSegment result = container.ListBlobsSegmentedAsync(null).Result;
            foreach (IListBlobItem item in result.Results)
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobs.Add(blob.Name + "#" + blob.Uri.ToString());
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory blob = (CloudBlobDirectory)item;
                    blobs.Add(blob.Uri.ToString());
                }
            }
            ViewBag.NewsImage = blobs;

            return View();
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Content,PublishDateTime")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,Title,Content,PublishDateTime")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
