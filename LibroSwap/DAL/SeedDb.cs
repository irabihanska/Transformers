using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public static class SeedDb
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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

                    new Country() { Id = 1, CountryName = "Україна", CountryCode = "UA" },
                    new Country() { Id = 2, CountryName = "Англія", CountryCode = "EN" },
                    new Country() { Id = 3, CountryName = "Шотландія", CountryCode = "SCOT" },
                    new Country() { Id = 4, CountryName = "Франція", CountryCode = "FR" }

                );

            modelBuilder.Entity<City>().HasData(

                    new City() { Id = 1, CityName = "Львів", CityCode = "LV", CountryId = 1 },
                    new City() { Id = 2, CityName = "Київ", CityCode = "KYI", CountryId = 1 },
                    new City() { Id = 3, CityName = "Лондон", CityCode = "LND", CountryId = 2 },
                    new City() { Id = 4, CityName = "Париж", CityCode = "PRS", CountryId = 4 }
                
                );

        }
    }
}
