using Vouchee.BusinessObject.Entities.Enums;

namespace Vouchee.BusinessObject.Entities;

public class Transaction
{
    
    //Attribute
    public Guid TransactionId { get; set; }
    public DateTime TransactionDateTime { get; } = DateTime.Now;
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    
    
}