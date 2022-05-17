using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
namespace LiquidRepositories
{
    public interface IVGPG
    {
        public VGPG Set(string? vgpg);
        public void Add(VGPG vGPG);
    }
}
