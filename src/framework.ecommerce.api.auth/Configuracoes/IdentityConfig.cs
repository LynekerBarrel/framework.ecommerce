using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using framework.ecommerce.auth.Extensions;
using framework.ecommerce.auth.Data;
using framework.ecommerce.auth.Models;
using framework.ecommerce.util.Config;

namespace framework.ecommerce.auth.Configuration
{
    /// <summary>
    /// IdentityConfig
    /// </summary>
    public static class IdentityConfig
    {
        /// <summary>
        /// AddIdentityConfiguration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql("server=localhost;port=3306;user=root;password=LinkxD@12;database=framework")); // EnvironmentConfig.ConnectionStrings

            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}