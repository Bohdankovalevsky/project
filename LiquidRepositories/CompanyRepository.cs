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
    public class CompanyRepository: ICompany
    {
        private readonly ApplicationDbContext _ctx;
        public CompanyRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Company Set(string company)
        {
            var companies = _ctx.companies.Where(p => p.CompanyName == company).FirstOrDefault();
            if (companies == null)
            {
                Company company1 = new Company();
                {
                    company1.CompanyName = company;
                }
                Add(company1);
                return company1;
            }
            else
                return companies;
        }
        public void Add(Company company)
        {
            _ctx.companies.Add(company);
            _ctx.SaveChanges();
        }
       
    }
    
}
