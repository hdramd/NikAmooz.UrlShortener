using MediatR;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateShortUrlCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
