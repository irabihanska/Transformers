using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Genres")]
    public class Genre : Entity
    {
        [Column("genre_name"), StringLength(255), Required]
        public string GenreName { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<Book> SecondaryBooks { get; set; }

        public ICollection<Book> TertiaryBooks { get; set; }
    }
}
