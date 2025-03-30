using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Extensions;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("IdentityDbConnectionString");
            services.AddDbContextPool<IdentityContext>((sp, options) =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mysqlOptions =>
                {
                    mysqlOptions.CommandTimeout(25000);
                    mysqlOptions.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName);
                });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.AddScoped<IdentityDbContextInitialiser>();

            return services;
        }
    }
}
