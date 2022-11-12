using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikAmooz.UrlShortener.Domain.Entities;
using NikAmooz.UrlShortener.Infrastructure.Persistence.Base;

namespace NikAmooz.UrlShortener.Infrastructure.Persistence.Configurations
{
    public class ShortUrlConfiguration : EntityConfigurationBase<ShortUrl>
    {
        public override void Configure(EntityTypeBuilder<ShortUrl> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Path)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
