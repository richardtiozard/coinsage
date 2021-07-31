using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoinsAge.Models;

namespace CoinsAge.Data
{
    public class CoinsAge2Context : DbContext
    {
        public CoinsAge2Context (DbContextOptions<CoinsAge2Context> options)
            : base(options)
        {
        }

        public DbSet<CoinsAge.Models.News> News { get; set; }
    }
}
