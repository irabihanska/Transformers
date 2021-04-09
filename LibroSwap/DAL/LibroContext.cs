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

            modelBuilder.Entity<Language>().HasData(

                    new Language() { Id = 1, LanguageName = "Українська", LanguageCode = "UKR" },
                    new Language() { Id = 2, LanguageName = "Англійська", LanguageCode = "ENG" },
                    new Language() { Id = 3, LanguageName = "Французька", LanguageCode = "FRA" },
                    new Language() { Id = 4, LanguageName = "Китайська", LanguageCode = "CHI" } 
                );

            modelBuilder.Entity<Country>().HasData(
                
                    new Country() { Id = 1, CountryName = "Україна", CountryCode = "UA"},
                    new Country() { Id = 2, CountryName = "Англія", CountryCode = "EN" },
                    new Country() { Id = 3, CountryName = "Шотландія", CountryCode = "SCOT" },
                    new Country() { Id = 4, CountryName = "Франція", CountryCode = "FR" }

                );
        }

        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }
    }
}
