namespace MovieApp.Core.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class AppUser : IdentityUser<int>
    {
        public List<Ticket> ScreeningTickets { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
