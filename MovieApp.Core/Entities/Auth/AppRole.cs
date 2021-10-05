using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieApp.Core.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
