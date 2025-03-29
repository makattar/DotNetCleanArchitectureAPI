using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Extensions;

namespace Infrastructure.Persistence
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDbConnectionString");
            services.AddDbContextPool<ApplicationDbContext>((sp, options) =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mysqlOptions =>
                {
                    mysqlOptions.CommandTimeout(25000);
                });
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}
