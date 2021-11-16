using Application.Repositories;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Company.Query
{
    public interface IQueryCompanyRepository : IBaseRepository
    {
        IEnumerable<Core.Company> GetAllCompanies();
        Core.Company GetCompany(int Id);
    }
}
