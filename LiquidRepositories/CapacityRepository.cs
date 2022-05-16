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
    public class CapacityRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CapacityRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Capacity Set(int? capacity)
        {
            var capasities = _ctx.capacities.Where(p => p.Ml == capacity).FirstOrDefault();
            if (capasities == null)
            {
                Capacity capacity1 = new Capacity();
                {
                    capacity1.Ml = capacity;
                }
                Add(capacity1);
                return capacity1;
            }
            else
                return capasities;
        }

        public void Add(Capacity capacity)
        {
            _ctx.capacities.Add(capacity);
            _ctx.SaveChanges();
        }
    }
}
