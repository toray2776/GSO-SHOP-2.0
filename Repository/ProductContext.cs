using Bedienungshilfe.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedienungshilfe.Repository
{
    class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }

        public Product findById(int id)
        {
            Product product = this.Products.Find(id);

            return product;
        }

        public List<Product> FindAll()
        {
            List<Product> products = this.Products
                .Include(product => product.author)
                .Include(product => product.publisher)
                .Include(product => product.format)
                .Include(product => product.category)
                .ToList();

            return products;
        }
    }
}
