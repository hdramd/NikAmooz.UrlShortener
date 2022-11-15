using NikAmooz.UrlShortener.Application.Common.Interfaces;

namespace NikAmooz.UrlShortener.Application.Common.Services
{
    public class UrlShortener : IUrlShortener
    {
        public string GeneratePath(string url)
        {
            //TODO: Use a better algorithm for generation short url
           return string.Format("{0:x}", url.TrimEnd('/').GetHashCode());
        }
    }
}
