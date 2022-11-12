using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NikAmooz.UrlShortener.Api.Middlewares;

namespace NikAmooz.UrlShortener.Api.Installer
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllers(opt => opt.Filters.Add<OnExceptionMiddleware>())
               .AddFluentValidation();

            #region Swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NikAmooz Url Shortener API"
                });
            });

            #endregion Swagger

        }
    }
}
