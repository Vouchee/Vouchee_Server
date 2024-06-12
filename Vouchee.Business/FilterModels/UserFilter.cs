using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.FilterModels
{
    public class UserFilter
    {
        public UserFilter()
        {
            Notifies = new HashSet<NotifyFilter>();
            Transactions = new HashSet<TransactionFilter>();
            Products = new HashSet<ProductFilter>();
            Roles = new HashSet<RoleFilter>();
            Comments = new HashSet<CommentFilter>();
        }

        public Guid? UserId { get; set; }

        public string? Fullname { get; set; }

        public int? Gender { get; set; }

        public UserStatusEnum? UserStatusEnum { get; set; }

        public Guid? ShopId { get; set; }

        public virtual ShopFilter? Shop { get; set; }

        public Guid? WalletId { get; set; }

        public virtual WalletFilter? Wallet { get; set; }

        public virtual ICollection<NotifyFilter>? Notifies { get; set; }

        public virtual ICollection<RoleFilter>? Roles { get; set; }

        public virtual ICollection<TransactionFilter>? Transactions { get; set; }

        public virtual ICollection<ProductFilter>? Products { get; set; }

        public virtual ICollection<CommentFilter>? Comments { get; set; }
    }
}
