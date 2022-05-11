using System;
using LiquidInfo;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LiquidRepos
{
    internal class LiquidRepos
    {
        private readonly LiquidContext ctx;

        public LiquidRepos()
        {
            ctx = new LiquidContext();
        }

        public LiquidINfo Get(int id)
        {
            return ctx.LiquidInfos
                .Include(l => l.capacity)
                .Include(l => l.company)
                .Include(l => l.nicotine)
                .Include(l => l.vGPG)
            .First(d => d.Id == id);
        }

        public IEnumerable<LiquidINfo> GetAll()
        {
            return ctx.LiquidInfos
                .Include(l => l.capacity)
                .Include(l => l.company)
                .Include(l => l.nicotine)
                .Include(l => l.vGPG)
                .ToList();
        }
        public void Add(LiquidINfo info, int cpctid, string cmpnid, int nctnid, string vgpgid)
        {
            info.capacity = ctx.Capacities.Find(cpctid);
            info.company = ctx.Companies.Find(cmpnid);
            info.nicotine = ctx.Nicotines.Find(nctnid);
            info.vGPG = ctx.VGPGs.Find(vgpgid);
            ctx.LiquidInfos.Add(info);
            ctx.SaveChanges();
        }
        public void Update(LiquidINfo info, int cpctid, string cmpnid, int nctnid, string vgpgid)
        {
            info.capacity = ctx.Capacities.Find(cpctid);
            info.company = ctx.Companies.Find(cmpnid);
            info.nicotine = ctx.Nicotines.Find(nctnid);
            info.vGPG = ctx.VGPGs.Find(vgpgid);
            ctx.SaveChanges();

            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            ctx.LiquidInfos.Remove(ctx.LiquidInfos.Find(id));
            ctx.SaveChanges();

        }
    }
}
