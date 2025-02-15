using EShopBE.Domain;
using EShopBE.Domain.Entities;
using EShopBE.Models.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            var jwt = configuration.GetSection("JWT").Get<JwtConfiguration>();
            services.AddSingleton(jwt);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = jwt!.ValidIssuer;
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudiences = new string[] { jwt!.ValidAudience },
                    ValidIssuer = jwt!.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt!.Secret))
                };

            });

            return services;

        }
    }
}
