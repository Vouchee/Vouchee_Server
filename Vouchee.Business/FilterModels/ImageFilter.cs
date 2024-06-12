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
    public class ImageFilter
    {
        public Guid? ImageId { get; set; }

        public string? ImageUrl { get; set; }

        public ImageType? ImageType { get; set; }

        public Guid? ShopId { get; set; }

        public virtual ShopFilter? Shop { get; set; }
    }
}
