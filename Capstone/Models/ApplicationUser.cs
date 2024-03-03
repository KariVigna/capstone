using Microsoft.AspNetCore.Identity;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsParent { get; set; }
    }
}