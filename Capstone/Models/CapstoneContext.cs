using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Capstone.Models
{
    public class CapstoneContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Entry> Entries { get; set; }        
        public CapstoneContext(DbContextOptions     options) : base(options) { }
    }
}