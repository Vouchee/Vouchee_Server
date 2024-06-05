using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(c => c.ProductCategories)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId);
    }
}