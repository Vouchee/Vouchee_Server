namespace Vouchee.Domain.Entities;

public class UserProduct
{
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}