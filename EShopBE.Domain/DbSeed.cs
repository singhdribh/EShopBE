using EShopBE.Domain.Entities;
using EShopBE.Models.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Security.Claims;

namespace EShopBE.Domain
{
    public static class DbSeed
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();



            var contextFactory = scope.ServiceProvider.GetService<IDbContextFactory<EShopDbContext>>();
            using (var context = contextFactory.CreateDbContext())
            {

                context.Database.Migrate();
                var roles = context.Roles.Select(x => x.Name).ToList();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<RoleUserEntity>>();
                roleManager.CreateAsync(new RoleUserEntity("Admin")).GetAwaiter().GetResult();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUserEntity>>();
                var user = new ApplicationUserEntity
                {
                    CreatedBy = "AUTO",
                    CreatedAt = DateTimeOffset.Now,
                    Email = "testAdmin@yopmail.com",
                    Id = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirstName = "Test",
                    LastName = "Account",
                    PhoneNumber = "9999999999",
                    PhoneNumberConfirmed = true,
                    UserName = "testAdmin@yopmail.com"
                };
                userManager.CreateAsync(user, "Test@123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(user,"Admin").GetAwaiter().GetResult();
                userManager.AddClaimsAsync(user, [
                       new Claim(ClaimsConstants.Id, user.Id),
                            new Claim(ClaimsConstants.Email, user.Email),
                            new Claim(ClaimsConstants.Username, user.UserName),
                            new Claim(ClaimsConstants.Name, $"{user.FirstName} {user.LastName}")
                       ]).GetAwaiter().GetResult();

            }
            return app;
        }
    }
}
