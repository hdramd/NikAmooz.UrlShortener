namespace NikAmooz.UrlShortener.Application.Common.Interfaces
{
    public interface IUrlShortener
    {
        string GeneratePath(string url);
    }
}
