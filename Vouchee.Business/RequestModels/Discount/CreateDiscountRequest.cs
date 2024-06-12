﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Discount
{
    public class CreateDiscountRequest
    {
        [Required]
        [StringLength(100)]
        public string DiscountName { get; set; }

        [StringLength(500)]
        public string DiscountDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string DiscountCode { get; set; }

        [Required]
        public DiscountStatus DiscountStatus { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpireDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public Guid? ProductId { get; set; }
    }
}
