using CarPoolSystem.Services.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPoolSystem.Services.Identity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
