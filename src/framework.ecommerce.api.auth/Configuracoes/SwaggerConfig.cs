using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace framework.ecommerce.api.auth.Configuration
{
    /// <summary>
    /// SwaggerConfig
    /// </summary>
    public static class SwaggerConfig
    {
        private const string UriMit = "https://opensource.org/licenses/MIT";

        /// <summary>
        /// AddSwaggerConfiguration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "CliveControl - Identity Api",
                    Description = "Api responsável por realizar a autenticação;",
                    Contact = new OpenApiContact() { Name = "contato@clinicaclive.com.br", Email = "contato@clinicaclive.com.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri(UriMit) }
                });

            });

            return services;
        }

        /// <summary>
        /// UseSwaggerConfiguration
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}