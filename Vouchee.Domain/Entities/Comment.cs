using Vouchee.Domain.Common;
using Vouchee.Domain.Enums;

namespace Vouchee.Domain.Entities;

public class Comment : BaseAuditableEntity<Guid>
{
    public string Description { get; set; }
    public CommentStatus CommentStatus { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    
}