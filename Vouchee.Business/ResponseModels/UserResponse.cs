using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.ResponseModels
{
    public class UserResponse
    {
        public UserResponse()
        {
            Notifies = new HashSet<NotifyResponse>();
            Transactions = new HashSet<TransactionResponse>();
            Products = new HashSet<ProductResponse>();
            Roles = new HashSet<RoleResponse>();
            Comments = new HashSet<CommentResponse>();
        }

        public Guid UserId { get; set; }

        public string Fullname { get; set; }

        public int Gender { get; set; }

        public UserStatusEnum UserStatusEnum { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        public string UserPassword { get; set; }
        public Guid? ShopId { get; set; }

        public Guid? WalletId { get; set; }

        public virtual ICollection<NotifyResponse>? Notifies { get; set; }

        public virtual ICollection<RoleResponse> Roles { get; set; }

        public virtual ICollection<TransactionResponse>? Transactions { get; set; }

        public virtual ICollection<ProductResponse>? Products { get; set; }

        public virtual ICollection<CommentResponse>? Comments { get; set; }
    }
}
