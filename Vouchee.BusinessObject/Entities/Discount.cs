using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Discount
{
    [Key]
    public Guid DiscountId { get; set; }
    public string DiscountName { get; set; }
    public string DiscountDescription { get; set;}
    public string DiscountCode { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    public DateTime StartDate { get; set; }
    public DateTime ExpireDateTime { get; set; }
    public int Amount { get; set; }
}