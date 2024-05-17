using System.ComponentModel.DataAnnotations;

namespace Vouchee.BusinessObject.Entities;

public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string LocationCity { get; set; }
    public string LocationDistrict { get; set; }
    public string LocationWard { get; set; }
    public string LocationStreet { get; set; }
    public string LocationDetails { get; set; }
    
}