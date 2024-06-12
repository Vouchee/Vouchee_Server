using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Shop
{
    public class CreateShopRequest
    {
        [Required]
        [StringLength(100)]
        public string ShopName { get; set; }

        [StringLength(200)]
        public string ShopTitle { get; set; }

        public string ShopDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PercentShow { get; set; }

        public int ResponsibilityScore { get; set; }

        [Required]
        public ShopStatusEnum ShopStatus { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
