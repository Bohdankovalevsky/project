using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
namespace LiquidRepositories
{
    public interface INicotine
    {
        public Nicotine Set(int? nicotine);
        public void Add(Nicotine nicotine);
    }
}
