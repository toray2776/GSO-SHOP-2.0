using Bedienungshilfe.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedienungshilfe.Repository
{
    class ShoppingCartContext : DbContext
    {
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }

        public ShoppingCart FindActualCartForUser(User user)
        {
            ShoppingCart shoppingCart = this.ShoppingCarts
                .Include(s => s.shoppingCartItems)
                .ThenInclude(i => i.product)
                .Where(s => s.purchased == false)
                .Single(s => s.user == user);

            return shoppingCart;
        }
    }
}
