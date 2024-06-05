using Microsoft.AspNetCore.Identity;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string Fullname { get; set; }
    public required int Gender { get; set; }
    public UserStatusEnum UserStatusEnum { get; set; }

    public Shop? Shop { get; set; }
    public Guid? WalletId { get; set; }
    public Wallet? Wallet { get; set; }

    public ICollection<Notify> Notifies { get; set; } = new List<Notify>();
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}
