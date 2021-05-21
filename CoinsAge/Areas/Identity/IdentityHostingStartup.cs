using System;
using CoinsAge.Areas.Identity.Data;
using CoinsAge.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CoinsAge.Areas.Identity.IdentityHostingStartup))]
namespace CoinsAge.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CoinsAge1Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CoinsAge1ContextConnection")));

                services.AddDefaultIdentity<CoinsAge1User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CoinsAge1Context>();
            });
        }
    }
}