using GraphQL.GraphQL.Mutations;
using GraphQL.GraphQL.Query;
using GraphQL.Models.Repos.CEORepo;
using GraphQL.Models.Repos.CompanyRepo;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<ICompanyRepo, CompanyRepo>();
            services.AddSingleton<ICeoRepo, CeoRepo>();

            services.AddControllers();

            services.AddGraphQLServer()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
            //services.AddGraphQL(SchemaBuilder.New().AddQueryType<Query>().AddMutationType<Mutation>().Create());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/graphql");
            });
        }
    }
}
