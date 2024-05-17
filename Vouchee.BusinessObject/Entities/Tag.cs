using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Tag
{
    [Key]
    public int TagId { get; set; }
    public string TagName { get; set; }
    
}