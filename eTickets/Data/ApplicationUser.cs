using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace eTickets.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }

    }
}
