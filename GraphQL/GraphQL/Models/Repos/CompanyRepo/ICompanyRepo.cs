using System.Collections.Generic;

namespace GraphQL.Models.Repos.CompanyRepo
{
    public interface ICompanyRepo
    {
        Company Get(int id);
        IEnumerable<Company> GetAll();
        Company Add(Company company);
        Company Update(Company company);
        void Delete(int id);

    }
}
