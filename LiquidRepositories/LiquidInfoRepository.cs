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
    public class LiquidInfoRepository :Iliquidinfo
    {
        private readonly ApplicationDbContext ctx;
        public LiquidInfoRepository(ApplicationDbContext cotx)
        {
            ctx = cotx;
        }

        public LiquidINfo Get(int id)
        {
            return ctx.LInfo
                .Include(l => l.company)
                .Include(l => l.capacity)
                .Include(l => l.nicotine)
                .Include(l => l.vGPG)
                .FirstOrDefault(d => d.Id == id);
        }
        public void Delete(int id)
        {
            ctx.LInfo.Remove(ctx.LInfo.Find(id));
            ctx.SaveChanges();
        }
        public void Edit(LiquidINfo model)
        {
            ctx.LInfo.First(x => x.Id == model.Id).taste = model.taste;
            ctx.LInfo.First(x => x.Id == model.Id).capacity = model.capacity;
            ctx.LInfo.First(x => x.Id == model.Id).company = model.company;
            ctx.LInfo.First(x => x.Id == model.Id).nicotine = model.nicotine;
            ctx.LInfo.First(x => x.Id == model.Id).vGPG = model.vGPG;
            ctx.LInfo.First(x => x.Id == model.Id).description=model.description;
            ctx.LInfo.First(x => x.Id == model.Id).picture = model.picture;
             ctx.SaveChanges();
        }
        public void Create(LiquidINfo model, int capid, int comid, int nicid, int vgpgid)
        {
            model.capacity= ctx.capacities.Find(capid);
            model.company = ctx.companies.Find(comid);
            model.nicotine = ctx.nicotines.Find(nicid);
            model.vGPG = ctx.vgps.Find(vgpgid);

             ctx.LInfo.Add(model);
             ctx.SaveChanges();
        }

        public IEnumerable<LiquidINfo> GetAll()
        {
             return ctx.LInfo
                .Include(d => d.capacity)
                .Include(d => d.company)
                .Include(d => d.nicotine)
                .Include(d => d.vGPG).
                ToList();
        }
        public IEnumerable<LiquidINfo> searcher(string text)
        {
            return ctx.LInfo.Include(x => x.company).Where(x => x.company.CompanyName.Contains(text) || x.taste.Contains(text)).ToList();
        }



    }
}
