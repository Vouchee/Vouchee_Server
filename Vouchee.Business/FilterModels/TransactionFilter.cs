﻿using System;
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
    public class TransactionFilter
    {
        public Guid? TransactionId { get; set; }

        public string? TransactionDetail { get; set; }

        public DateTime? TransactionDateTime { get; set; }

        public TransactionType? TransactionType { get; set; }

        public TransactionStatusEnum? TransactionStatusEnum { get; set; }

        public decimal? Amount { get; set; }

        public Guid? UserId { get; set; }

        /*public virtual UserFilter? User { get; set; }*/
    }
}
