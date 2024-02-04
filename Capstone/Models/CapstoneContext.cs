using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
    public class CapstoneContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories {get; set;}
        
        public CapstoneContext(DbContextOptions     options) : base(options) { }
    }
}