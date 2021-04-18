using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options) { }

        // addnig dbsets
        // include only those db sets for whose you can query directly
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Models)
                .WithOne(model => model.Manufacturer)
                .HasForeignKey(model => model.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
