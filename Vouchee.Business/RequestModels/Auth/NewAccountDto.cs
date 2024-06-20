using System.ComponentModel.DataAnnotations;

namespace Vouchee.Business.RequestModels.Auth;

public class NewAccountDto
{
    public required Guid Id { get; set; }

    [Required]
    public required string Fullname { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public IList<string> Roles = new List<string>();
    
    public  string? Token { get; set; }
}