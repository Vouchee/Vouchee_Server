namespace Vouchee.Domain.Entities;

public class ShopPromotion 
{
    public Guid ShopId { get; set; }
    public Shop? Shop { get; set; }

    public Guid PromotionId { get; set; }
    public Promotion? Promotion { get; set; }

}