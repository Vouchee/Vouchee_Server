using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Location
{
    public class CreateLocationRequest
    {
        [StringLength(100)]
        public string LocationCity { get; set; }

        [StringLength(100)]
        public string LocationDistrict { get; set; }

        [StringLength(100)]
        public string LocationWard { get; set; }

        [StringLength(200)]
        public string LocationStreet { get; set; }

        [StringLength(500)]
        public string LocationDetails { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public Guid ShopId { get; set; }
    }
}
