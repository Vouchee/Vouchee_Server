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
    public class DiscountFilter
    {
        public Guid? DiscountId { get; set; }

        public string? DiscountName { get; set; }

        public string? DiscountDescription { get; set; }

        public string? DiscountCode { get; set; }

        public DiscountStatus? DiscountStatus { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ExpireDateTime { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid? ProductId { get; set; }

        public virtual ProductFilter? Product { get; set; }
    }
}
