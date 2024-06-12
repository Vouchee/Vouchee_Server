using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.ResponseModels
{
    public class LocationResponse
    {
        public Guid LocationId { get; set; }

        public string LocationCity { get; set; }

        public string LocationDistrict { get; set; }

        public string LocationWard { get; set; }

        public string LocationStreet { get; set; }

        public string LocationDetails { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid ShopId { get; set; }
    }
}
