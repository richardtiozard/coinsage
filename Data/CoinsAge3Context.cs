using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoinsAge.Models;

namespace CoinsAge.Data
{
    public class CoinsAge3Context : DbContext
    {
        public CoinsAge3Context (DbContextOptions<CoinsAge3Context> options)
            : base(options)
        {
        }

        public DbSet<CoinsAge.Models.News> News { get; set; }
    }
}
