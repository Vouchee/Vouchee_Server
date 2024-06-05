using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class NotifyConfiguration : IEntityTypeConfiguration<Notify>
{
    public void Configure(EntityTypeBuilder<Notify> builder)
    {
        builder.HasOne(n => n.User)
            .WithMany(n => n.Notifies);
    }
}