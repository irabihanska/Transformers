using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("BookAuthors")]
    public class BookAuthor : Entity
    {
        [Column("author_name"), StringLength(200), Required]
        public string AuthorName { get; set; }

        [Column("author_surname"), StringLength(200), Required]
        public string AuthorSurname { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<Book> TranslatedBooks { get; set; }
    }
}
