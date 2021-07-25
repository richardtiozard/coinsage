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
                                   join userRole in _context.UserRoles
                                   on user.Id equals userRole.UserId
                                   join role in _context.Roles
                                   on userRole.RoleId equals role.Id
                                   where role.Name == "User"
                                   select user)
                               .ToListAsync();

            return View();
        }
    }
}
