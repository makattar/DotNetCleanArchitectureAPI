using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Extensions
{
    public static class InitialiserExtension
    {
        public static void InitialiseIdentityDatabaseAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var initialiser = scope.ServiceProvider.GetRequiredService<IdentityDbContextInitialiser>();
            Task.WaitAll(initialiser.InitialiseAsync());
            Task.WaitAll(initialiser.SeedAsync());
        }
    }
    public class IdentityDbContextInitialiser
    {
        private readonly ILogger<IdentityDbContextInitialiser> _logger;
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityDbContextInitialiser(ILogger<IdentityDbContextInitialiser> logger, IdentityContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            await Seeds.DefaultRoles.SeedAsync(_userManager, _roleManager);
            await Seeds.DefaultSuperAdmin.SeedAsync(_userManager, _roleManager);
        }
    }
}
