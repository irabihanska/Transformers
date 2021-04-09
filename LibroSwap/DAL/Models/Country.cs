using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Countries")]
    public class Country : Entity
    {
        [Column("country_name"), StringLength(200), Required]
        public string CountryName { get; set; }

        [Column("country_code"), StringLength(3), Required]
        public string CountryCode { get; set; }
    }
}
