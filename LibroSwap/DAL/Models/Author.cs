using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Authors")]
    public class Author : Entity
    {
        [Column("author_name"), StringLength(200), Required]
        public string AuthorName { get; set; }

        [Column("author_surname"), StringLength(200), Required]
        public string AuthorSurname { get; set; }
    }
}
