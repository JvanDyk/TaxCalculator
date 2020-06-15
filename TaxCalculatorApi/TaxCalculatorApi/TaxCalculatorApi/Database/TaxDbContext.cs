using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorApi.Entities;

namespace TaxCalculatorApi.Database
{
    public class TaxDbContext : DbContext
    {
        public DbSet<CalculatedEntity> Taxes { get; set; }
        public TaxDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculatedEntity>(
                x =>
                {
                    x.ToTable("Calculated");
                    x.HasKey(e => e.Id);
                    x.Property(key => key.Id).ValueGeneratedOnAdd();

                    x.Property(prop => prop.AnnualIncome).IsRequired();
                    x.Property(prop => prop.PostalCode).IsRequired();
                    x.Property(prop => prop.Calculated).IsRequired();
                });
        }
    }
}
