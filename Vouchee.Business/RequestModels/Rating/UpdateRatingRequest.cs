using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Business.RequestModels.Rating
{
    public class UpdateRatingRequest
    {
        public string RatingTitle { get; set; }

        public RatingType RatingType { get; set; }

        public string RatingContent { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
