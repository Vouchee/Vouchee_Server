using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(c => c.Product)
            .WithMany(c => c.Comments);
        builder.HasOne(c => c.User)
            .WithMany(c => c.Comments);
    }
}