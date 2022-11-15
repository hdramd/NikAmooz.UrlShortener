using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Application.Common.Models;
using NikAmooz.UrlShortener.Application.ShortUrls.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Queries
{
    public class GetShortUrlQuery : IRequest<Result<ShortUrlDto>>
    {
        public string Path { get; set; }
    }

    public class GetShortUrlQueryHandler : IRequestHandler<GetShortUrlQuery, Result<ShortUrlDto>>
    {
        private readonly IApplicationDbContext _context;
        public GetShortUrlQueryHandler(IApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ShortUrlDto>> Handle(GetShortUrlQuery request,
            CancellationToken cancellationToken)
        {
            var shortUrl = await _context.ShortUrls
                 .FirstOrDefaultAsync(x => x.Path.Equals(request.Path), cancellationToken);

            if (shortUrl is null)
                return Result<ShortUrlDto>.Failed(new BadRequestObjectResult(
                    new ApiMessage("Short url not found.")));

            //TODO: Use automapper
            return Result<ShortUrlDto>.SuccessFul(new ShortUrlDto
            {
                Id = shortUrl.Id,
                Path = shortUrl.Path,
                Destination = shortUrl.Destination,
                Count = shortUrl.Count
            });
        }
    }
}
