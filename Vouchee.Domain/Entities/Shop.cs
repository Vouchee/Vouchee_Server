using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Shop : BaseAuditableEntity<Guid>
{
    public string ShopName { get; set; }
    public string ShopTitle { get; set; }
    public string ShopDescription { get; set; }
    public int PercentShow { get; set; }
    public int ResponsibilityScore { get; set; }
    public ShopStatusEnum ShopStatus { get; set; }
    
    public required Guid OwnerId { get; set; }
    public User? Owner { get; set; }

    public ICollection<ShopImages> ShopImages = new List<ShopImages>();
    public Location ShopLocations { get; set; }
    
    public ICollection<ShopPromotion> ShopPromotions = new List<ShopPromotion>();
}