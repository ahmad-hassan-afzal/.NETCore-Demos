using System.Collections.Generic;

namespace GraphQL.Models.Repos.CEORepo
{
    public interface ICeoRepo
    {
        CEO Get(int id);
        IEnumerable<CEO> GetAll();
        CEO Add(CEO ceo);
        CEO Update(CEO ceo);
        void Delete(int id);

    }
}
