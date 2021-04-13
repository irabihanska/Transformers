using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("LibCountries")]
    public class Country : Entity
    {
        [Column("country_name"), StringLength(200), Required]
        public string CountryName { get; set; }

        [Column("country_code"), StringLength(5), Required]
        public string CountryCode { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
