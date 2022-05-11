using LiquidCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidRepos
{
    public class NicotineRepos
    {
        private readonly LiquidContext ctx;

        public NicotineRepos()
        {
            ctx = new LiquidContext();
        }
        public Nicotine Set(int mg)
        {

            var nicotie = ctx.Nicotines.Where(c => c.Mg == mg).FirstOrDefault();
            if (nicotie == null)
            {
                Nicotine nic1 = new()
                {
                    Mg = mg,

                };
                Add(nic1);
                return nic1;
            }
            else
                return nicotie;

        }

        public IEnumerable<Nicotine> GetAll()
        {
            return ctx.Nicotines.ToList();
        }

        public void Add(Nicotine name)
        {
            ctx.Nicotines.Add(name);
            ctx.SaveChanges();
        }
    }
}
