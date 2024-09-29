using CoffeeVendingMachineApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachineApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeCreamer> CoffeeCreamers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coffee>()
                .HasMany(f => f.Characteristics)
                .WithOne(n => n.Coffee)
                .HasForeignKey(n => n.CoffeeId);
        }
    }
}
