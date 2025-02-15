using EShopBE.Domain;
using EShopBE.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EShopBE
{
    public static class ProgramInstaller
    {

        public static IServiceCollection AddProgramInstaller(this IServiceCollection services,IConfigurationManager configuration) {


            services.AddHttpContextAccessor();
            services.AddIdentity<ApplicationUserEntity,RoleUserEntity>(configuration =>
            {

            }).AddEntityFrameworkStores<EShopDbContext>().AddDefaultTokenProviders();
            var sqlConnection = configuration.GetConnectionString("Connection");

            services.AddDbContextFactory<EShopDbContext>(option =>
            {
                option.UseSqlServer(sqlConnection).EnableServiceProviderCaching(false);
                option.EnableSensitiveDataLogging(false);
            });
            return services;

        }
    }
}
