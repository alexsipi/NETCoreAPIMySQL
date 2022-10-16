using Microsoft.EntityFrameworkCore;
using Repository.Pattern.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Repository.Pattern.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
    }
}
