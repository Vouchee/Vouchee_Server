using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Wallet : BaseAuditableEntity<Guid>
{
    public decimal WalletAmount { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }
    
    
}
