using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Promotion
{
    [Key]
    public Guid PromotionId { get; set; }
    public string PromotionTitle { get; set; }
    public string PromotionDetails { get; set; }
    public string PromotionCode { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    public DateTime StartDate { get; set; }
    public DateTime ExpiredDate { get; set; }
}