using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Product : BaseAuditableEntity<Guid>
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal ProductDiscountPrice { get; set; }
    public int Amount { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string ProductPolicy { get; set; }
    public string ProductCode { get; set; }
    public string ProductCodeImage { get; set; }

    public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();


}