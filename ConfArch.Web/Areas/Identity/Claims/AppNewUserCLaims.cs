using ConfArch.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConfArch.Web.Areas.Identity.Claims
{
    //for adding claims alone
    // public class AppNewUserCLaims : UserClaimsPrincipalFactory<ConfArchWebUser>

    /// <summary>
    /// For adding claims and User roles to the Idenity
    /// </summary>
    public class AppNewUserCLaims : UserClaimsPrincipalFactory<ConfArchWebUser, IdentityRole>
    {

        //public AppNewUserCLaims(UserManager<ConfArchWebUser> userManager, IOptions<IdentityOptions> options)
        //    : base(userManager, options): base(userManager, options)

        public AppNewUserCLaims(
            UserManager<ConfArchWebUser> userManager,
            IOptions<IdentityOptions> options, 
            RoleManager<IdentityRole> roleManager) : base(userManager, roleManager, options)
        => (_userManager, _options, _roleManager) = (userManager, options, roleManager);


        public UserManager<ConfArchWebUser> _userManager { get; }
        public IOptions<IdentityOptions> _options { get; }
        public RoleManager<IdentityRole> _roleManager { get; }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ConfArchWebUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // Add custom claims to the cookie
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;

        }
    }
}
