using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Books")]
    public class Book : Entity
    {
        [Column("title"), StringLength(255), Required]
        public string Title { get; set; }

        [Column("current_owner_id")]
        public int CurrentOwnerId { get; set; }

        public User CurrentOwner { get; set; }

        [Column("genre_id")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Column("secondary_genre_id")]
        public int? SecondaryGenreId { get; set; }

        public Genre SecondaryGenre { get; set; }

        [Column("tertiary_genre_id")]
        public int? TertiaryGenreId { get; set; }

        public Genre TertiaryGenre { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [Column("book_coverage_id")]
        public int BookCoverageId { get; set; }

        public BookCoverage BookCoverage { get; set; }

        [Column("bookhouse_id")]
        public int BookhouseId { get; set; }

        public Bookhouse Bookhouse { get; set; }

        [Column("city_id")]
        public int CityId { get; set; }

        public City City { get; set; }

        [Column("author_id")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Column("translator_id")]
        public int? TranslatorId { get; set; }

        public Author Translator { get; set; }

        public bool Translation { get; set; }

        public uint Pages { get; set; }

        public uint Year { get; set; }
    }
}
