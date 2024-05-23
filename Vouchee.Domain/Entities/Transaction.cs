using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Transaction : BaseAuditableEntity<Guid>
{
    public PaymentMethod PaymentMethod { get; set; }
    public double Amount { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; }
    
    public Guid ReservationId { get; set; }
}