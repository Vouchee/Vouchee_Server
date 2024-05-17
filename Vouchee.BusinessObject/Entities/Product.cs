using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Product
{
    [Key]
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal ProductDiscountPrice { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string ProductPolicy { get; set; }
    public string ProductCode { get; set; }
    public string ProductCodeImage { get; set; }
    
    
    public ICollection<string?> ProductImages = new List<string?>();

}