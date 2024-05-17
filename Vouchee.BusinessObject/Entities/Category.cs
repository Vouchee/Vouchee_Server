using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryTitle { get; set; }
}