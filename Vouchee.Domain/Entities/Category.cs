using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Category : BaseEntity<Guid>
{
    public string CategoryTitle { get; set; }
    public string CategoryDescription { get; set; }
    
    public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

}