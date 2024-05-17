using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Comment
{
    [Key]
    public Guid CommentId { get; set; }
    public string CommentContent { get; set; }
    public DateTime CommentTime { get; set; }
    
    
}