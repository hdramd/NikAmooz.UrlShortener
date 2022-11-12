using MediatR;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommand : IRequest<int>
    {
        public string Url { get; set; }
    }
}
