using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Test
{
    public class BaseTest : IClassFixture<Fixture>
    {
        protected readonly ServiceProvider Services;
        protected readonly CommandContext CommandContext;
        protected readonly QueryContext QueryContext;
        protected BaseTest(Fixture fixture)
        {
            Services = fixture.ServiceProvider;
            CommandContext = Services.GetService<CommandContext>();
            QueryContext = Services.GetService<QueryContext>();
            if (CommandContext != null && CommandContext.Database.EnsureCreated())
                CommandContext.SeedSampleData();
        }
        public static void Destroy(QueryContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}
