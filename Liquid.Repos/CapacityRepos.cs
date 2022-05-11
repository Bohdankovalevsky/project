using LiquidCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidRepos
{
    public class CapacityRepos
    {
        private readonly LiquidContext ctx;

        public CapacityRepos()
        {
            ctx = new LiquidContext();
        }

        public Capacity Set(int capacity)
        {

            var capacities = ctx.Capacities.Where(c => c.Ml == capacity).FirstOrDefault();
            if (capacities == null)
            {
                Capacity capacity1 = new()
                {
                    Ml = capacity,

                };
                Add(capacity1);
                return capacity1;
            }
            else
                return capacities;

        }



        public IEnumerable<Capacity> GetAll()
        {
            return ctx.Capacities.ToList();
        }

        public void Add(Capacity capacity)
        {
            ctx.Capacities.Add(capacity);
            ctx.SaveChanges();
        }



        public void Delete(int id)
        {
            ctx.Capacities.Remove(ctx.Capacities.Find(id));
            ctx.SaveChanges();
        }

    }
}