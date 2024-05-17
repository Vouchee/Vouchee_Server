using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Wallet
{
    [Key]
    public Guid WalletId { get; set; }
    public decimal WalletAmount { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}