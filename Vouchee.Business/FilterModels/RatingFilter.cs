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
    public class RatingFilter
    {
        public Guid? RatingId { get; set; }

        public string? RatingTitle { get; set; }

        public RatingType? RatingType { get; set; }

        public string? RatingContent { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid? ProductId { get; set; }

        /*public virtual Product? Product { get; set; }*/
    }
}
