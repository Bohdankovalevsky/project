using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
using LiquidWebApp.Data;
using Microsoft.EntityFrameworkCore;
namespace LiquidRepositories
{
    public class NicotineRepository
    {
        private readonly ApplicationDbContext _ctx;
        public NicotineRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Nicotine Set(int? mg)
        {
            var nicotines = _ctx.nicotines.Where(p => p.Mg == mg).FirstOrDefault();
            if (nicotines == null)
            {
                Nicotine mg1 = new Nicotine();
                {
                    mg1.Mg = mg;
                }
                Add(mg1);
                return mg1;
            }
            else
                return nicotines;
        }
        public void Add(Nicotine nicotine)
        {
            _ctx.nicotines.Add(nicotine);
            _ctx.SaveChanges();
        }
    }
}
