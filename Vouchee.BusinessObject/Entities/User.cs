using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Vouchee.BusinessObject.Entities.Enums;

namespace Vouchee.BusinessObject.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string UserEmail { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    public UserStatus UserStatus { get; set; }

    public ICollection<Role> Roles = new List<Role>();
    public Wallet? Wallet { get; set; }
}   