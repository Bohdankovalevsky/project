using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidCore;
namespace LiquidRepositories
{
    public interface ICompany

    {
        public Company Set(string? companyn);
        public void Add(Company company);
    }
}
