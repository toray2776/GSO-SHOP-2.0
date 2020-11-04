using Bedienungshilfe.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedienungshilfe.Repository
{
    class ShoppingCartItemContext : DbContext
    {
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }

        public ShoppingCartItem FindByProductTitleAndShoppingCart(ShoppingCart shoppingCart, string title)
        {
            ShoppingCartItem shoppingCartItem = this.ShoppingCartItems
                .Include(i => i.product)
                .Include(i => i.product.author)
                .Include(i => i.product.publisher)
                .Include(i => i.product.format)
                .Include(i => i.product.category)
                .Single(i => i.product.title == title);

            return shoppingCartItem;
        }
    }
}
