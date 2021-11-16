using GraphQL.Models;
using GraphQL.Models.Repos.CEORepo;
using HotChocolate;
using System.Linq;

namespace GraphQL.GraphQL.Mutations
{
    public class CeoMutation
    {
        public CEO AddCeo([Service] ICeoRepo repo, CEO ceo)
        {
            repo.Add(ceo);
            return ceo;
        }


        public CEO UpdateCeo([Service] ICeoRepo repo, CEO ceo)
        {
            repo.Update(ceo);
            return ceo;
        }


        public CEO DeleteCeo([Service] ICeoRepo repo, int id)
        {
            repo.Delete(id);
            return repo.GetAll().FirstOrDefault(x => x.Id == id);
        }

    }

}