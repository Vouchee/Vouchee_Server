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

        [Required]
        public UserStatusEnum UserStatusEnum { get; set; }

        public Guid? ShopId { get; set; }

        [Required]
        public Guid WalletId { get; set; }
    }
}
