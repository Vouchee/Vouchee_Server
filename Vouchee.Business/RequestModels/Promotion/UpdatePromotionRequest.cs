using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Business.RequestModels.Promotion
{
    public class UpdatePromotionRequest
    {
        [Required]
        [StringLength(100)]
        public string PromotionTitle { get; set; }

        [StringLength(500)]
        public string PromotionDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string PromotionCode { get; set; }

        [Required]
        public PromotionStatus PromotionStatus { get; set; }

        [Required]
        public PromotionType PromotionType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
