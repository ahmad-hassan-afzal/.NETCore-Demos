using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Extensions.Repositories
{
    public static class RepositoriesExt
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            var types = typeof(IBaseRepository).Assembly.GetTypes();
            types.Where(type => typeof(IBaseRepository).IsAssignableFrom(type) && !type.IsInterface).ToList()
                .ForEach(type => services.AddScoped(type.GetInterface($"I{type.Name}"), type));
        }
    }
}
