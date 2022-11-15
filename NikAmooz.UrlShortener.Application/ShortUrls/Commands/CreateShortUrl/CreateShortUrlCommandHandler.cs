using MediatR;
using Microsoft.AspNetCore.Http;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Application.Common.Models;
using NikAmooz.UrlShortener.Application.ShortUrls.Models;
using NikAmooz.UrlShortener.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, Result<ShortUrlDto>>
    {
        private readonly IUrlShortener _urlShortener;
        private readonly IApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        public CreateShortUrlCommandHandler(IUrlShortener urlShortener,
            IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _urlShortener = urlShortener;
            _context = context;
            _httpContext = httpContextAccessor?.HttpContext ??
                throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<Result<ShortUrlDto>> Handle(CreateShortUrlCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new ShortUrl
            {
                Path = _urlShortener.GeneratePath(request.Url),
                Destination = request.Url
            };

            _context.ShortUrls.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //TOOD: Use Automapper
            return Result<ShortUrlDto>.SuccessFul(new ShortUrlDto
            {
                Id = entity.Id,
                Path = $"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}/{entity.Path}"
            });
        }
    }
}
