using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CandyStore.Models;

namespace CandyStore.Data
{
    public class CandyContext : DbContext
    {
        public CandyContext (DbContextOptions<CandyContext> options)
            : base(options)
        {
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Production>().ToTable("Production");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<Buyer>().ToTable("Buyer");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
        }
    }
}
