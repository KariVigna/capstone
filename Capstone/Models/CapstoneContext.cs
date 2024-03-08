using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
    public class CapstoneContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<KidPrize> KidPrizes { get; set; }
        public CapstoneContext(DbContextOptions options) : base(options) { }
    }
}