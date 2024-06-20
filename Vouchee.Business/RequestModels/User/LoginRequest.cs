using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.ResponseModels;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.User
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "The User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(UserPassword))]
        public string ConfirmPass { get; set; }
        public virtual ICollection<RoleResponse> Roles { get; set; }
    }
}
