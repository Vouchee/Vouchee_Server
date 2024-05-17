using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vouchee.BusinessObject.Entities.Enums;

namespace Vouchee.BusinessObject.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public ICollection<User> Users = new List<User>();
}