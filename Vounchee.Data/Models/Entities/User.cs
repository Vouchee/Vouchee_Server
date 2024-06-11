﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vounchee.Data.Models.Constants.Enum;

namespace Vounchee.Data.Models.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Notifies = new HashSet<Notify>();
            Transactions = new HashSet<Transaction>();
            Products = new HashSet<Product>();
            Roles = new HashSet<Role>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

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
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
