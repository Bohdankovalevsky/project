using System;
using System.Collections.Generic;
using LiquidInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidRepos
{
    internal class VGPGRepos
    {
        private readonly LiquidContext ctx;

        public VGPGRepos()
        {
            ctx = new LiquidContext();
        }
        public VGPG Set(string vgpg)
        {

            var VP = ctx.VGPGs.Where(c => c.VgPg == vgpg).FirstOrDefault();
            if (VP == null)
            {
                VGPG vGPG1 = new()
                {
                    VgPg = vgpg,

                };
                Add(vGPG1);
                return vGPG1;
            }
            else
                return VP;

        }

        public IEnumerable<VGPG> GetAll()
        {
            return ctx.VGPGs.ToList();
        }

        public void Add(VGPG name)
        {
            ctx.VGPGs.Add(name);
            ctx.SaveChanges();
        }

    }
}
