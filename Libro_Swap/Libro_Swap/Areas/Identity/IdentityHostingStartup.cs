using System;
using Libro_Swap.Areas.Identity.Data;
using Libro_Swap.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Libro_Swap.Areas.Identity.IdentityHostingStartup))]
namespace Libro_Swap.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Libro_SwapDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Libro_SwapDBContextConnection")));

                services.AddDefaultIdentity<Libro_SwapUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<Libro_SwapDBContext>();
            });
        }
    }
}