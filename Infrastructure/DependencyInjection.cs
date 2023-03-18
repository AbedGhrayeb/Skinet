using System.Runtime.CompilerServices;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddDbContext<StoreContext>(options=>{
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IProductRepository,ProductRepository>();
            return services;
        }
    }
}