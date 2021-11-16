using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Fixture
    {
        public readonly ServiceProvider ServiceProvider;
        public readonly CommandContext CommandContext;
        public readonly QueryContext QueryContext;
        public Fixture()
        {
           
            var services = new ServiceCollection();

            services.AddDbContextPool<CommandContext>(options =>
            {
                options.UseInMemoryDatabase("testDb");
            });
            services.AddDbContextPool<QueryContext>(options =>
            {
                options.UseInMemoryDatabase("testDb");
            });

            services.RegisterRepositories();
            ServiceProvider = services.BuildServiceProvider();
            CommandContext = ServiceProvider.GetService<CommandContext>();
            QueryContext = ServiceProvider.GetService<QueryContext>();
        }


    }
}
