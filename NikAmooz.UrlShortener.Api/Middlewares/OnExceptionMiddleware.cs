using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using NikAmooz.UrlShortener.Application.Common.Models;
using Serilog;

namespace NikAmooz.UrlShortener.Api.Middlewares
{
    public class OnExceptionMiddleware : IExceptionFilter
    {
        private readonly IHostEnvironment _env;

        public OnExceptionMiddleware(IHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiMessage();

            if (_env.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error occurred";
                error.Detail = context.Exception.Message;
            }

            Log.Error(context.Exception, context.Exception.Message, context.Exception.StackTrace);

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
