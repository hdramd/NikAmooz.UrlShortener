using NikAmooz.UrlShortener.Domain.Common;

namespace NikAmooz.UrlShortener.Domain.Entities
{
    public class ShortUrl : BaseEntity
    {
        public string Path { get; set; }
        public string Destination { get; set; }
        public int Count { get; set; }
    }
}
