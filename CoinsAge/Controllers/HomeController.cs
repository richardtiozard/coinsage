using CoinsAge.Data;
using CoinsAge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoinsAge1Context _context;

        public HomeController(ILogger<HomeController> logger, CoinsAge1Context context)
        {
            _logger = logger;
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

        public IActionResult Index()
        {
            ViewBag.News = _context.News
                .Include(p => p.Category)
                .OrderByDescending(q => q.PublishDateTime)
                .Take(6);

            ViewBag.Category = _context.Category;

            ViewBag.TrendingNews = _context.TrendingNews
                .Include(p => p.News)
                .ThenInclude(q => q.Category);

            ViewBag.PopularNews = _context.PopularNews
                .Include(p => p.News)
                .ThenInclude(q => q.Category);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
