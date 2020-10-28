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
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }
    }
}
