namespace GraphQL.GraphQL.Mutations
{
    public class Mutation
    {
        public CompanyMutation Company() => new CompanyMutation();
        public CeoMutation Ceo() => new CeoMutation();
    }

}