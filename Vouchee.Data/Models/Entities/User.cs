using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Data.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        
        public User()
        {
            Notifies = new HashSet<Notify>();
            Transactions = new HashSet<Transaction>();
            Products = new HashSet<Product>();
            Roles = new HashSet<UserRole>();
            Comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public UserStatusEnum UserStatusEnum { get; set; }

        public Guid? ShopId { get; set; }

        public virtual Shop? Shop { get; set; }

        [Required]
        public Guid WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }

        public virtual ICollection<Notify>? Notifies { get; set; }

        [Required]
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
