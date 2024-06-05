using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class ShopImages : BaseEntity<Guid>
{
    public string ImageUrl { get; set; }
    public ImageType ImageType { get; set; }
    
    public Guid ShopId { get; set; }
    public Shop? Shop { get; set; }
}