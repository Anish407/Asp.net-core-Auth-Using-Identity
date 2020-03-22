using System;
using ConfArch.Web.Areas.Identity.Claims;
using ConfArch.Web.Areas.Identity.Data;
using ConfArch.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ConfArch.Web.Areas.Identity.IdentityHostingStartup))]
namespace ConfArch.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ConfArchWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ConfArchWebContextConnection")));

                services.AddIdentity<ConfArchWebUser,IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true; })
                    .AddEntityFrameworkStores<ConfArchWebContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ConfArchWebUser>, AppNewUserCLaims>();

                services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "960311372373-26r5vu9ejl4lm4hcb3tcht85r68kdsdq.apps.googleusercontent.com";
                    options.ClientSecret = "uR5DvcKxpQ-7jOVszQP7zJIM";
                });
            });
        }
    }
}