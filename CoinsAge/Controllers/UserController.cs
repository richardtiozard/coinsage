using CoinsAge.Areas.Identity.Data;
using CoinsAge.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class UserController : Controller
    {
        private readonly CoinsAge1Context _context;

        public UserController(CoinsAge1Context context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = await (from user in _context.Users
                                   join userRole in _context.UserRoles.Where(x=> x.RoleId == "2")
                                   on user.Id equals userRole.UserId
                                   join role in _context.Roles
                                   on userRole.RoleId equals role.Id
                                   select user)
                               .ToListAsync();
            /*ViewBag.Users = await _context.Users.ToListAsync();*/

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id.Equals(id));

            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Destroy(string id)
        {


            foreach (var news in _context.News.Where(x => x.User.Id == id))
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

            var users = await _context.Users.FindAsync(id.ToString());
            _context.Users.Remove(users);

            await _context.SaveChangesAsync();
            return Redirect("/User");

        }
    }
}
