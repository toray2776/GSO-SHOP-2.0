using Bedienungshilfe.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedienungshilfe.Repository
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=shop.db");
        }

        public User FindById(int id)
        {
            User user = this.Users.Find(id);

            return user;
        }

        public User FindByUsername(string username)
        {
            User user = this.Users
                .Include(u => u.shoppingCarts)
                .Where(u => u.userName == username)
                .Single();

            return user;
        }
    }
}
