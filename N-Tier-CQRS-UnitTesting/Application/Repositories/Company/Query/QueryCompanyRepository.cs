using Application.Repositories;
using Core;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories.Company.Query
{
    public class QueryCompanyRepository :  IQueryCompanyRepository 
    {

        private readonly QueryContext _context;
        private readonly DbSet<Core.Company> _companies;
        public QueryCompanyRepository(QueryContext context)
        {
            _context = context;
            _companies = context.Company;
        }


        public IEnumerable<Core.Company> GetAllCompanies()
            => _companies;

        public Core.Company GetCompany(int CompanyId)
            => _companies.Find(CompanyId);


    }
}

