namespace GraphQL.GraphQL.Query
{
    public class Query
    {
        public CompanyQuery Company() => new CompanyQuery();
        public CeoQuery Ceo() => new CeoQuery();
    }
}
