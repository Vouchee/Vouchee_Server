using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.FilterModels
{
    public class RoleFilter
    {
        public RoleFilter()
        {
            /*Users = new HashSet<UserFilter>();*/
        }

        public Guid? RoleId { get; set; }

        public string? RoleName { get; set; }

        /*public virtual ICollection<UserFilter>? Users { get; set; }*/
    }
}
