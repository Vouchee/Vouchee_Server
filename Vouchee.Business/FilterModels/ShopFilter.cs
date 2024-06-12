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
    public class ShopFilter
    {
        public ShopFilter()
        {
            Images = new HashSet<ImageFilter>();
            Locations = new HashSet<LocationFilter>();
            Promotions = new HashSet<PromotionFilter>();
        }

        public Guid? ShopId { get; set; }

        public string? ShopName { get; set; }

        public string? ShopTitle { get; set; }

        public string? ShopDescription { get; set; }

        public decimal? PercentShow { get; set; }

        public int? ResponsibilityScore { get; set; }

        public ShopStatusEnum? ShopStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid? UserId { get; set; }

        public virtual UserFilter? User { get; set; }

        public virtual ICollection<ImageFilter>? Images { get; set; }

        public virtual ICollection<LocationFilter>? Locations { get; set; }

        public virtual ICollection<PromotionFilter>? Promotions { get; set; }
    }
}