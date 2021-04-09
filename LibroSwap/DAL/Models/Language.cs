using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models
{
    [Table("Languages")]
    public class Language : Entity
    {
        [Column("language_name"), StringLength(20), Required]
        public string LanguageName { get; set; }

        [Column("language_code"), StringLength(3), Required]
        public string LanguageCode { get; set; }
    }
}
