using Microsoft.AspNetCore.Identity;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string Fullname { get; set; }
    public required int Gender { get; set; }
    public UserStatusEnum UserStatusEnum { get; set; }

    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
}
