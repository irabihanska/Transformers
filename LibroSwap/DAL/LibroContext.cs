using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LibroContext : DbContext
    {
        public DbSet<BookCoverage> Coverages { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCoverage>().HasData(
                    new BookCoverage() { Id = 1, CoverageName = "Тверда" },
                    new BookCoverage() { Id = 2, CoverageName = "М'яка" }
                );

            modelBuilder.Entity<Genre>().HasData(

                    new Genre() { Id = 1, GenreName = "Проза" },
                    new Genre() { Id = 2, GenreName = "Поезія" },
                    new Genre() { Id = 3, GenreName = "Драматургія" }
                                        );
        }

        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }
    }
}
