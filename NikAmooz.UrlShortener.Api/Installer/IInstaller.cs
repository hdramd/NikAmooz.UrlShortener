using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NikAmooz.UrlShortener.Api.Installer
{
    public interface IInstaller
    {
        void InstallServices(IConfiguration configuration, IServiceCollection services);
    }
}
