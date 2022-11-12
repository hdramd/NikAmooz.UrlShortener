using Microsoft.EntityFrameworkCore;
using NikAmooz.UrlShortener.Application.Common.Interfaces;
using NikAmooz.UrlShortener.Domain.Common;
using NikAmooz.UrlShortener.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        #region DbSet

        public DbSet<ShortUrl> ShortUrls => Set<ShortUrl>(); 

        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "Heidar Ahmadi";//TODO: Inject ICurrentUserService and read from it!
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = string.Empty;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
