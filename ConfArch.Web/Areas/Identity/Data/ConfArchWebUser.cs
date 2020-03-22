using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ConfArch.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ConfArchWebUser class
    public class ConfArchWebUser : IdentityUser
    {
        public DateTime CareerStartDate { get; set; }

        public string FullName { get; set; }
    }
}
