using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
namespace LiquidRepositories
{
    public interface ICapacity
    {
        
        public Capacity Set(int? capacity);
        public void Add(Capacity capacity);
    }
}
