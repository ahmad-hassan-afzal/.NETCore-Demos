using HotChocolate;

namespace GraphQL.Models
{
    public class CEO
    {
        [GraphQLNonNullType]
        public int Id { get; set; }

        [GraphQLNonNullType]
        public string Name { get; set; }
    }
}
