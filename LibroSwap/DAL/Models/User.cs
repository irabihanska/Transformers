using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Users")]
    public class User : Entity
    {
        [Column("username"), StringLength(200), Required]
        public string UserName { get; set; }

        [Column("name"), StringLength(200)]
        public string Name { get; set; }

        [Column("surname"), StringLength(200)]
        public string Surname { get; set; }

        [Column("email"), StringLength(100), Required]
        public string Email { get; set; }

        [Column("phone"), StringLength(20)]
        public string Phone { get; set; }

        [Column("about_me"), StringLength(int.MaxValue), Required]
        public string AboutMe { get; set; }

        [Column("recommendation"), StringLength(int.MaxValue)]
        public string Recommendation { get; set; }

        [Column("city_id"), ]
        public int? CityId { get; set; }

        public City City { get; set; }
    }
}
