﻿using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(u => u.UserName).HasMaxLength(191);
                entity.Property(u => u.Email).HasMaxLength(191);
                entity.Property(u => u.NormalizedUserName).HasMaxLength(191);
                entity.Property(u => u.NormalizedEmail).HasMaxLength(191);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(u => u.Name).HasMaxLength(191);
                entity.Property(u => u.NormalizedName).HasMaxLength(191);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
