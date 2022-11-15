using MediatR;
using NikAmooz.UrlShortener.Application.Common.Models;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands
{
    public class IncreaseVisitCountCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

}
