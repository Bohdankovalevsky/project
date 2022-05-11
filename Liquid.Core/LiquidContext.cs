using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiquidCore
{
    public class LiquidContext : DbContext
    {
        public LiquidContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Capacity> Capacities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<LiquidINfo> LiquidInfos { get; set; }
        public DbSet<Nicotine> Nicotines { get; set; }
        public DbSet<VGPG> VGPGs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.\;Database=Liquids;Trusted_Connection=True;");
        }
    }

}
