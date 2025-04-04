using API.Extension;
using Application;
using Infrastructure.Identity;
using Infrastructure.Identity.Extensions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Extensions;
using Infrastructure.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API
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
            services.AddApplicationServices();
            services.AddInfrastructurePersistenceServices(Configuration);
            services.AddInfrastructureIdentityServices(Configuration);
            services.AddSharedInfrastructure(Configuration);
            services.AddApiVersioningExtension();
            services.AddSwaggerExtension();
            services.AddHttpContextExtension();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.InitialiseAppDatabaseAsync();
                app.InitialiseIdentityDatabaseAsync();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
