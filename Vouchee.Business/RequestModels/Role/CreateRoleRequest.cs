using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.RequestModels.Role
{
    public class CreateRoleRequest
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
