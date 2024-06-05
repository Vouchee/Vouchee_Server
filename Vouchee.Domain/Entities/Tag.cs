using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Tag : BaseEntity<int>
{
    public string TagName { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

}