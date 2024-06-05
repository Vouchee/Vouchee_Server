using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataContext.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Roles)
            .WithOne(u => u.User);

        builder.HasOne(u => u.Wallet)
            .WithOne(u => u.User);

        builder.HasMany(u => u.UserProducts)
            .WithOne(u => u.Owner);
    }
}