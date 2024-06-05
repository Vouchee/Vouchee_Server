using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Promotion : BaseAuditableEntity<Guid>
{
    public string PromotionTitle { get; set; }
    public string PromotionDetails { get; set; }
    public string PromotionCode { get; set; }
    public PromotionStatus PromotionStatus { get; set; }
    public PromotionType PromotionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public ICollection<ShopPromotion> ShopPromotions = new List<ShopPromotion>();
}