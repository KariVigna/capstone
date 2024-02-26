using Microsoft.AspNetCore.Identity;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }

}