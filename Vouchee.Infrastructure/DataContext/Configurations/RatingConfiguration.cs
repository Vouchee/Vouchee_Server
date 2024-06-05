using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class RatingConfiguration: IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasOne(r => r.Product)
            .WithMany(r => r.Ratings);
    }
}