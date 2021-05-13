using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using DAL.Interfaces;

namespace DAL.Models
{
    // Add profile data for application users by adding properties to the Libro_SwapUser class
    public class Libro_SwapUser : IdentityUser<int>, IEntity
    {
        public int Id { get { return base.Id; } set { base.Id = value; } }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column("phone"), StringLength(20)]
        public string Phone { get; set; }

        [Column("about_me"), StringLength(int.MaxValue)]
        public string AboutMe { get; set; }

        [Column("recommendation"), StringLength(int.MaxValue)]
        public string Recommendation { get; set; }

        [Column("city_id"),]
        public int? CityId { get; set; }

        public City City { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
