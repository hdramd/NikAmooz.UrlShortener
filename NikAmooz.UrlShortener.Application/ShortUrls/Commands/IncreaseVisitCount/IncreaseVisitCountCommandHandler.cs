using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands
{
    public class IncreaseVisitCountCommandHandler
        : IRequestHandler<IncreaseVisitCountCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        public IncreaseVisitCountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(IncreaseVisitCountCommand request,
            CancellationToken cancellationToken)
        {
            var shortUrl = await _context.ShortUrls
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (shortUrl is null)
                return Result<int>.Failed(new BadRequestObjectResult(
                    new ApiMessage($"Short url with id {request.Id} not found.")));

            shortUrl.Count++;

            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.SuccessFul(shortUrl.Count);
        }
    }
}
