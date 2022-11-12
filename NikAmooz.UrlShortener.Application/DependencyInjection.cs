using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NikAmooz.UrlShortener.Application.Common.Behaviours;

namespace NikAmooz.UrlShortener.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
