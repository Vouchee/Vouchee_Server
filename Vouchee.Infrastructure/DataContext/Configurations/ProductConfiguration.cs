using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.UserProducts)
            .WithOne(p => p.Product);

        builder.HasMany(p => p.ProductTags)
            .WithOne(p => p.Product);
        
        builder.HasMany(p => p.ProductCategories)
            .WithOne(p => p.Product);
    }
}