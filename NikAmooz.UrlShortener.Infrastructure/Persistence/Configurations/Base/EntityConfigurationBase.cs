using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikAmooz.UrlShortener.Domain.Common;

namespace NikAmooz.UrlShortener.Infrastructure.Persistence.Base
{
    public abstract class EntityConfigurationBase<TEnity> : IEntityTypeConfiguration<TEnity>
        where TEnity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEnity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created)
                .IsRequired();
            builder.Property(x => x.CreatedBy)
                .IsRequired();
            builder.Property(x => x.Deleted)
                .IsRequired();
        }
    }
}
