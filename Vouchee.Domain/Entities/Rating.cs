using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Rating : BaseAuditableEntity<Guid>
{
    public string RatingTitle { get; set; }
    public RatingType RatingType { get; set; }
    public string RatingContent { get; set; }
    
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}