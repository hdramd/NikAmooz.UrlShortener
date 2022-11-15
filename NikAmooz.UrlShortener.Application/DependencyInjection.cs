using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NikAmooz.UrlShortener.Application.Common.Behaviours;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using System.Reflection;

namespace NikAmooz.UrlShortener.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddSingleton<IUrlShortener, Common.Services.UrlShortener>();

            return services;
        }
    }
}
