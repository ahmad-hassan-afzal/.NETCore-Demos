using GraphQL.Models;
using HotChocolate;
using GraphQL.Models.Repos.CompanyRepo;
using System.Linq;

namespace GraphQL.GraphQL.Mutations
{
    public class CompanyMutation
    {
        public Company AddCompany([Service] ICompanyRepo repo, Company company)
        {
            repo.Add(company);
            return company;
        }


        public Company UpdateCompany([Service] ICompanyRepo repo, Company company)
        {
            repo.Update(company);
            return company;
        }


        public Company DeleteCompany([Service] ICompanyRepo repo, int id)
        {
            repo.Delete(id);
            return repo.GetAll().FirstOrDefault(x => x.Id == id);
        }

    }

}