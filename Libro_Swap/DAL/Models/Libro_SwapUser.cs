using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using DAL.Interfaces;

namespace DAL.Models
{
    // Add profile data for application users by adding properties to the Libro_SwapUser class
    public class Libro_SwapUser : IdentityUser<int>, IEntity
    {
        public int Id { get { return base.Id; } private set { base.Id = value; } }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
