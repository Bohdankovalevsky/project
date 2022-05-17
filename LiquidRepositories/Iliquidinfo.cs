using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
namespace LiquidRepositories
{
    public interface Iliquidinfo
    {
        public  void Edit(LiquidINfo model);
        public void Create(LiquidINfo model, int capid, int comid, int nicid, int vgpgid);
        public LiquidINfo Get(int id);
        public void Delete(int id);
        public IEnumerable<LiquidINfo> GetAll();
        public IEnumerable<LiquidINfo> searcher(string text);
    }
}
