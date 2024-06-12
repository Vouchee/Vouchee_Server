using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.ResponseModels
{
    public class RoleResponse
    {
        public RoleResponse()
        {
            Users = new HashSet<UserResponse>();
        }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<UserResponse> Users { get; set; }
    }
}
