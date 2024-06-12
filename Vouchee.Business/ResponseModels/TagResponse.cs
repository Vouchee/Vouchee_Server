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
    public class TagResponse
    {
        public TagResponse()
        {
            Products = new HashSet<ProductResponse>();
        }

        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public virtual ICollection<ProductResponse> Products { get; set; }
    }
}
