using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Cities")]
    public class City : Entity
    {
        [Column("city_name"), StringLength(200), Required]
        public string CityName { get; set; }

        [Column("city_code"), StringLength(5), Required]
        public string CityCode { get; set; }

        [Column("CountryId"), Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Bookhouse> Bookhouses { get; set; }
    }
}
