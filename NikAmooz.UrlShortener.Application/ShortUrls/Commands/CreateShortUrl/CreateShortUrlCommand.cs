using MediatR;
using NikAmooz.UrlShortener.Application.Common.Models;
using NikAmooz.UrlShortener.Application.ShortUrls.Models;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommand : IRequest<Result<ShortUrlDto>>
    {
        public string Url { get; set; }
    }
}
