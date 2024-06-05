using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class ShopPromotionConfiguration : IEntityTypeConfiguration<ShopPromotion>
{
    public void Configure(EntityTypeBuilder<ShopPromotion> builder)
    {
        builder.HasKey(sp => new {sp.PromotionId, sp.ShopId});
    }
}