using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CoinsAge.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CoinsAge.Data;
using CoinsAge.Models;
using CoinsAge.Controllers;

namespace CoinsAge.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<CoinsAge1User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UserManager<CoinsAge1User> _userManager;
        private readonly CoinsAge1Context _context;

        public LogoutModel(SignInManager<CoinsAge1User> signInManager, ILogger<LogoutModel> logger, UserManager<CoinsAge1User> userManager, CoinsAge1Context context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            CoinsAge1User loggeduser = await _userManager.GetUserAsync(User);
            DateTime dtnow = DateTime.Now;
            string now = dtnow.ToString().Replace(" ", "").Replace("/", "").Replace(":", "");
            Logging log = new Logging(loggeduser.Id, now)
            {
                email = loggeduser.Email,
                fullname = loggeduser.FullName,
                activity = "Log Out",
                datetime = dtnow
            };
            TableController tc = new TableController();
            tc.UploadEntity(log).Wait();

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
