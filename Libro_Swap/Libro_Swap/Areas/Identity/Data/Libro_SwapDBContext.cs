using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libro_Swap.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libro_Swap.Data
{
    public class Libro_SwapDBContext : IdentityDbContext<Libro_SwapUser>
    {
        public Libro_SwapDBContext(DbContextOptions<Libro_SwapDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
