using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Roles)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);

        builder.HasOne(u => u.Wallet)
            .WithOne(u => u.User)
            .HasForeignKey<Wallet>(u => u.UserId)
            .IsRequired();

        builder.HasMany(u => u.UserProducts)
            .WithOne(u => u.Owner)
            .HasForeignKey(u => u.OwnerId);
    }
}