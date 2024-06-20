using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.User
{
    public class CreateUserRequest
    {
        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }

        [Required]
        public int Gender { get; set; }
        [Required(ErrorMessage = "The User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        public UserStatusEnum UserStatusEnum { get; set; }

        public Guid? ShopId { get; set; }

        public Guid? WalletId { get; set; }
    }
}
