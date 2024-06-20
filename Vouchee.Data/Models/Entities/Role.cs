using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Vouchee.Data.Models.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> Roles = new List<UserRole>();
    }
}
