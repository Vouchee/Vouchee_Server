using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Notify : BaseAuditableEntity<Guid>
{
    public String Title { get; set; }
    public String Description { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
}