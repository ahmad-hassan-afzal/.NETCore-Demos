using GraphQL.Models;
using GraphQL.Models.Repos.CEORepo;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL.GraphQL.Query
{
    public class CeoQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        //[UseOffsetPaging]
        public IQueryable<CEO> GetCeos([Service] ICeoRepo repo)
           => repo.GetAll().AsQueryable();

    }
}
