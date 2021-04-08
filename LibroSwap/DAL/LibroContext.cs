using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LibroContext : DbContext
    {
        public DbSet<Coverage> Coverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coverage>().HasData(
                    new Coverage() { CoverageName = "Тверда" },
                    new Coverage() { CoverageName = "М'яка" }
                );
        }

        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }
    }
}
