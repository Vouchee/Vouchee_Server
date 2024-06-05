using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Location : BaseAuditableEntity<int>
{
    public string LocationCity { get; set; }
    public string LocationDistrict { get; set; }
    public string LocationWard { get; set; }
    public string LocationStreet { get; set; }
    public string LocationDetails { get; set; }
    
    public Guid ShopId { get; set; }
    public Shop? Shop { get; set; }
    
}