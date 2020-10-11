using Bedienungshilfe.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public User findById(int id)
        {
            User user = this.Users.Find(id);

            return user;
        }
    }
}
