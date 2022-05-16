using LiquidCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiquidWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }
        public DbSet<LiquidINfo> LInfo { get; set; }
        public DbSet<Capacity> capacities { get; set; } 
        public DbSet<Company> companies { get; set; }
        public DbSet<Nicotine> nicotines { get; set; } 
        public DbSet<VGPG> vgps { get; set; }
    }
}