using MediatR;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Application.Common.Models;
using NikAmooz.UrlShortener.Application.ShortUrls.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, Result<ShortUrlDto>>
    {
        private readonly IApplicationDbContext _context;
        public CreateShortUrlCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Result<ShortUrlDto>> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
