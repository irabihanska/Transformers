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


            modelBuilder.Entity<Author>().HasData(
                
                    new Author() { Id = 1, AuthorName = "Софія", AuthorSurname = "Андрухович" },
                    new Author() { Id = 2, AuthorName = "Оксана", AuthorSurname = "Забужко" },
                    new Author() { Id = 3, AuthorName = "Луїза", AuthorSurname = "Хей" },
                    new Author() { Id = 4, AuthorName = "Вадим", AuthorSurname = "Зеланд" },
                    new Author() { Id = 5, AuthorName = "Джоан", AuthorSurname = "Роулінг" }

                );

            modelBuilder.Entity<Bookhouse>().HasData(
                
                    new Bookhouse() { Id = 1, BookhouseName = "Видавництво Старого Лева", CityId = 1},
                    new Bookhouse() { Id = 2, BookhouseName = "Видавництво Івана Малковича „А-ба-ба-га-ла-ма-га", CityId = 2},
                    new Bookhouse() { Id = 3, BookhouseName = "Bloomsbury", CityId = 3}
                );

            modelBuilder.Entity<User>().HasData(
                
                    new User() { Id = 1, UserName = "Cardify", Email = "mbeecker8@deviantart.com", CityId = 4, AboutMe = "Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor." },
                    new User() { Id = 2, UserName = "Voyatouch", Email = "ktolmanm@php.net", CityId = 3, AboutMe = "Pellentesque ultrices mattis odio. Donec vitae nisi." },
                    new User() { Id = 3, UserName = "Konklab", Email = "tcothey1t@gmpg.org", AboutMe = "Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti." },
                    new User() { Id = 4, UserName = "Ronstring", Email = "jmundow1y@sfgate.com", CityId = 2, AboutMe = "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit." },
                    new User() { Id = 5, UserName = "Flowdesk", Email = "tshimman1a@wp.com", CityId = 1, AboutMe = "In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit." }

                );
        }
    }
}
