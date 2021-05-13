using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class Libro_SwapDBContext : IdentityDbContext <Libro_SwapUser, IdentityRole<int>, int>
    {
        public DbSet<BookCoverage> Coverages { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<BookAuthor> Authors { get; set; }

        public DbSet<Bookhouse> Bookhouses { get; set; }

        public DbSet<Book> Books { get; set; }

        public Libro_SwapDBContext(DbContextOptions<Libro_SwapDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<BookCoverage>().ToTable("BookCoverages");

            modelBuilder.Entity<Genre>().ToTable("Genres");

            modelBuilder.Entity<Language>().ToTable("Languages");

            modelBuilder.Entity<Country>().ToTable("LibCountries");

            modelBuilder.Entity<City>()
                .HasOne<Country>(cnt => cnt.Country)
                .WithMany(cts => cts.Cities)
                .HasForeignKey(cnt => cnt.CountryId)
                .IsRequired();

            modelBuilder.Entity<City>().ToTable("Cities");

            modelBuilder.Entity<BookAuthor>().ToTable("BookAuthors");

            modelBuilder.Entity<Bookhouse>()
                .HasOne<City>(bh => bh.City)
                .WithMany(ct => ct.Bookhouses)
                .HasForeignKey(bh => bh.CityId)
                .IsRequired();

            modelBuilder.Entity<Bookhouse>().ToTable("Bookhouses");

            modelBuilder.Entity<Libro_SwapUser>()
                .HasOne<City>(u => u.City)
                .WithMany(ct => ct.Users)
                .HasForeignKey(u => u.CityId);

            modelBuilder.Entity<Libro_SwapUser>().ToTable("Users");

            modelBuilder.Entity<Book>()
                .HasOne<Libro_SwapUser>(b => b.CurrentOwner)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.CurrentOwnerId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne<Genre>(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne<Genre>(b => b.SecondaryGenre)
                .WithMany(g => g.SecondaryBooks)
                .HasForeignKey(b => b.SecondaryGenreId);

            modelBuilder.Entity<Book>()
                .HasOne<Genre>(b => b.TertiaryGenre)
                .WithMany(g => g.TertiaryBooks)
                .HasForeignKey(b => b.TertiaryGenreId);

            modelBuilder.Entity<Book>()
                .HasOne<Language>(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne<BookCoverage>(b => b.BookCoverage)
                .WithMany(bc => bc.Books)
                .HasForeignKey(b => b.BookCoverageId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne<Bookhouse>(b => b.Bookhouse)
                .WithMany(bh => bh.Books)
                .HasForeignKey(b => b.BookhouseId);

            modelBuilder.Entity<Book>()
                .HasOne<City>(b => b.City)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                .HasOne<BookAuthor>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne<BookAuthor>(b => b.Translator)
                .WithMany(t => t.TranslatedBooks)
                .HasForeignKey(b => b.TranslatorId);

            modelBuilder.Entity<Book>().ToTable("Books");

            modelBuilder.Seed();
        }
    }
}
