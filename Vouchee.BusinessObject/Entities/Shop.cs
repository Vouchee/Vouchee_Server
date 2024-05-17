using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Shop
{
    [Key]
    public Guid ShopId { get; set; }
    public string ShopName { get; set; }
    public string ShopDescription { get; set; }
    public string ShopBackgroundImage { get; set; }
    public string ShopProfileImage { get; set; }
    public int ResponseScore { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    
}