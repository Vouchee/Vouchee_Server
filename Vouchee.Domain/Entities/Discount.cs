using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Discount : BaseAuditableEntity<Guid>
{ 
    public string DiscountName { get; set; }
    public string DiscountDescription { get; set;}
    public string DiscountCode { get; set; }
    public DiscountStatus DiscountStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDateTime { get; set; }
    public int Amount { get; set; }
    
    public Guid ProductID { get; set; }
    public Product? Product { get; set; }
}