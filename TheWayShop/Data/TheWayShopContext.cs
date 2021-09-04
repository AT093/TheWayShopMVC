using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheWayShop.Models;

namespace TheWayShop.Data
{
    public class TheWayShopContext : DbContext
    {
        public TheWayShopContext (DbContextOptions<TheWayShopContext> options)
            : base(options)
        {
        }
        public DbSet<Items> Items { get; set; }
        public DbSet<YourItems> YourItems { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
