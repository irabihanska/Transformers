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

        public DbSet<Language> Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCoverage>().ToTable("Coverages");

            modelBuilder.Entity<Genre>().ToTable("Genres");

            modelBuilder.Entity<Language>().ToTable("Languages");

            modelBuilder.Entity<Country>().ToTable("Countries");

            modelBuilder.Entity<City>()
                .HasOne<Country>(cnt => cnt.Country)
                .WithMany(cts => cts.Cities)
                .HasForeignKey(cnt => cnt.CountryId);

            modelBuilder.Entity<City>().ToTable("Cities");

            modelBuilder.Entity<Author>().ToTable("Authors");

            modelBuilder.Entity<Bookhouse>()
                .HasOne<City>(bh => bh.City)
                .WithMany(ct => ct.Bookhouses)
                .HasForeignKey(bh => bh.CityId);

            modelBuilder.Entity<Bookhouse>().ToTable("Bookhouses");

            modelBuilder.Seed();
        }

        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }
    }
}
