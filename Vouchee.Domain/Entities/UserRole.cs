using Microsoft.AspNetCore.Identity;

namespace Vouchee.Domain.Entities;

public class UserRole : IdentityUserRole<Guid>
{   
    public Guid UserId { get; set; }
    public required User User { get; set; }  
    public Guid RoleId { get; set; }
    public required Role Role { get; set; }
}