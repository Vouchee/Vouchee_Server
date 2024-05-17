using System.ComponentModel.DataAnnotations;
using Vouchee.BusinessObject.Entities.Enums;

namespace Vouchee.BusinessObject.Entities;

public class Rating
{
    [Key]
    public Guid RatingId { get; set; }
    public string RatingTitle { get; set; }
    public RatingType RatingType { get; set; }
    public string RatingContent { get; set; }
    public DateTime RatingDate { get; } = DateTime.Now;
    
    
}