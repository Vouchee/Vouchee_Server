using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class ShopImagesConfiguration : IEntityTypeConfiguration<ShopImages>
{
    public void Configure(EntityTypeBuilder<ShopImages> builder)
    {
        builder.HasOne(si => si.Shop)
            .WithMany(si => si.ShopImages);
    }
}