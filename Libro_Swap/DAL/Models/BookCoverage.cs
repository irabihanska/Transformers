using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("BookCoverages")]
    public class BookCoverage : Entity
    {
        [Column("coverage_name"), StringLength(255), Required]
        public string CoverageName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
