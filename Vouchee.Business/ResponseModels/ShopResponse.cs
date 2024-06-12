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
    public class ShopResponse
    {
        public ShopResponse()
        {
            Images = new HashSet<ImageResponse>();
            Locations = new HashSet<LocationResponse>();
            Promotions = new HashSet<PromotionResponse>();
        }

        public Guid ShopId { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public string ShopDescription { get; set; }

        public decimal PercentShow { get; set; }

        public int ResponsibilityScore { get; set; }

        public ShopStatusEnum ShopStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid UserId { get; set; }

        public virtual ICollection<ImageResponse>? Images { get; set; }

        public virtual ICollection<LocationResponse>? Locations { get; set; }

        public virtual ICollection<PromotionResponse>? Promotions { get; set; }
    }
}
