using Microsoft.EntityFrameworkCore;
using NikAmooz.UrlShortener.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        #region DbSets

        DbSet<ShortUrl> ShortUrls { get; } 

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
