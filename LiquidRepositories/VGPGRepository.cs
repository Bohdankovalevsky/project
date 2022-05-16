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
    public class VGPGRepository
    {
        private readonly ApplicationDbContext _ctx;
        public VGPGRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public VGPG Set(string vgpg)
        {
            var vgpgs = _ctx.vgps.Where(p => p.VgPg == vgpg).FirstOrDefault();
            if (vgpgs == null)
            {
                VGPG vgpg1 = new VGPG();
                {
                   vgpg1.VgPg = vgpg;
                }
                Add(vgpg1);
                return vgpg1;
            }
            else
                return vgpgs;
        }
        public void Add(VGPG vGPG)
        {
            _ctx.vgps.Add(vGPG);
            _ctx.SaveChanges();
        }
    }
}
