using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Application.ShortUrls.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ForwarderMiddleware
    {
        private readonly RequestDelegate _next;

        public ForwarderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IMediator mediator)
        {
            string path = httpContext.Request.Path;

            path = path.Trim('/');

            var result = await mediator.Send(new GetShortUrlQuery { Path = path });

            if (result.Success)
            {
                var response = httpContext.Response;
                response.Redirect(result.Data?.Destination, true);
                return;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ForwarderExtensions
    {
        public static IApplicationBuilder UseForwarder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ForwarderMiddleware>();
        }
    }
}
