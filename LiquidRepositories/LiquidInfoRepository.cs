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
    public class LiquidInfoRepository
    {
        private readonly ApplicationDbContext _ctx;
        public LiquidInfoRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public LiquidINfo Get(int id)
        {
            return _ctx.LInfo.FirstOrDefault(d => d.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.LInfo.Remove(await _ctx.LInfo.FirstAsync(x => x.Id == id)); 
            await _ctx.SaveChangesAsync();
        }
        public async Task EditAsync(LiquidINfo model)
        {
            _ctx.LInfo.First(x => x.Id == model.Id).taste = model.taste;
            _ctx.LInfo.First(x => x.Id == model.Id).capacity = model.capacity;
            _ctx.LInfo.First(x => x.Id == model.Id).company = model.company;
            _ctx.LInfo.First(x => x.Id == model.Id).nicotine = model.nicotine;
            _ctx.LInfo.First(x => x.Id == model.Id).vGPG = model.vGPG;
            _ctx.LInfo.First(x => x.Id == model.Id).description=model.description;
            _ctx.LInfo.First(x => x.Id == model.Id).picture = model.picture;
            await _ctx.SaveChangesAsync();
        }
        public async Task CreateAsync(LiquidINfo model)
        {
            await _ctx.LInfo.AddAsync(model);
            await _ctx.SaveChangesAsync();
        }

        /* public IEnumerable<LiquidINfo> GetAll()
         {
             return _ctx.LInfo.ToList();
         }*/
    }
}
