using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Image
{
    public class UpdateImageRequest
    {
        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        public ImageType ImageType { get; set; }

        public Guid? ShopId { get; set; }
    }
}
