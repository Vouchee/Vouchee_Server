using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Transaction : BaseAuditableEntity<Guid>
{
    public String TransactionDetail { get; set; }
    public DateTime TransactionDateTime { get; } = DateTime.Now;
    public TransactionType TransactionType { get; set; }
    public TransactionStatusEnum TransactionStatusEnum { get; set; }
    public decimal Amount { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
}