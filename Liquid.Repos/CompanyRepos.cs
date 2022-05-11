using LiquidCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidRepos
{
    public class CompanyRepos
    {
        private readonly LiquidContext ctx;

        public CompanyRepos()
        {
            ctx = new LiquidContext();
        }
        public Company Set(string companyN)
        {

            var companies = ctx.Companies.Where(c => c.CompanyName == companyN).FirstOrDefault();
            if (companies == null)
            {
                Company comp1 = new()
                {
                    CompanyName = companyN,

                };
                Add(comp1);
                return comp1;
            }
            else
                return companies;

        }

        public IEnumerable<Company> GetAll()
        {
            return ctx.Companies.ToList();
        }

        public void Add(Company company)
        {
            ctx.Companies.Add(company);
            ctx.SaveChanges();
        }

    }
}
