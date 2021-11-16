using GraphQL.Models;
using GraphQL.Models.Repos.CompanyRepo;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL.GraphQL.Query
{
    public class CompanyQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        //[UseOffsetPaging]
        public IQueryable<Company> GetCompanies([Service] ICompanyRepo repo)
           => repo.GetAll().AsQueryable();

    }
}
