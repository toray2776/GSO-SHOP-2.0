using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Bedienungshilfe.Entity;

namespace Bedienungshilfe
{
    public class ShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }
    }
}
