using CoinsAge.Data;
using CoinsAge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class DashboardController : Controller
    {

        private readonly CoinsAge1Context _context;

        public DashboardController(CoinsAge1Context context) 
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //Total Users
            ViewBag.TotalUsers = _context.Users.Count();

            //Total Users
            ViewBag.TotalAdmin = _context.UserRoles.Where(x => x.RoleId == 1.ToString()).Count();

            //Total Users
            ViewBag.TotalWriter = _context.UserRoles.Where(x => x.RoleId == 2.ToString()).Count();

            //Total News
            ViewBag.TotalNews = _context.News.Count();

            //Total Popular News
            ViewBag.TotalPopularNews = _context.PopularNews.Count();

            //Total Trending News
            ViewBag.TotalTrendingNews = _context.TrendingNews.Count();

            CloudTable ct = TableController.getTableStorage();
            ViewBag.Logging = ct.ExecuteQuery(new TableQuery<Logging>()).OrderByDescending(x => x.datetime).ToList();

            return View();
        }
    }
}
