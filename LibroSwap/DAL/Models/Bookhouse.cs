using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Bookhouses")]
    public class Bookhouse : Entity
    {
        [Column("bookhouse_name"), StringLength(200), Required]
        public string BookhouseName { get; set; }

        [Column("city_id"), Required]
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
