using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Role
{
    public class UpdateRoleRequest
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
