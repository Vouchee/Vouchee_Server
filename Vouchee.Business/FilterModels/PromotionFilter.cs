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
    public class PromotionFilter
    {
        public PromotionFilter()
        {
            Shops = new HashSet<ShopFilter>();
        }

        public Guid? PromotionId { get; set; }

        public string? PromotionTitle { get; set; }

        public string? PromotionDetails { get; set; }

        public string? PromotionCode { get; set; }

        public PromotionStatus? PromotionStatus { get; set; }

        public PromotionType? PromotionType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public virtual ICollection<ShopFilter>? Shops { get; set; }
    }
}
