using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Libro_Swap.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Libro_SwapUser class
    public class Libro_SwapUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
