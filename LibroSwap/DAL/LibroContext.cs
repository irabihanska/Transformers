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

        public DbSet<Author> Authors { get; set; }

        public DbSet<Bookhouse> Bookhouses { get; set; }

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
                .HasForeignKey(cnt => cnt.CountryId)
                .IsRequired();

            modelBuilder.Entity<City>().ToTable("Cities");

            modelBuilder.Entity<Author>().ToTable("Authors");

            modelBuilder.Entity<Bookhouse>()
                .HasOne<City>(bh => bh.City)
                .WithMany(ct => ct.Bookhouses)
                .HasForeignKey(bh => bh.CityId)
                .IsRequired();

            modelBuilder.Entity<Bookhouse>().ToTable("Bookhouses");

            modelBuilder.Entity<User>()
                .HasOne<City>(u => u.City)
                .WithMany(ct => ct.Users)
                .HasForeignKey(u => u.CityId);

            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Seed();
        }

        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }
    }
}
