using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.FilterModels
{
    public class CategoryFilter
    {
        public CategoryFilter()
        {
            Products = new HashSet<ProductFilter>();
        }

        public Guid? CategoryId { get; set; }

        public string? CategoryTitle { get; set; }

        public string? CategoryDescription { get; set; }

        public virtual ICollection<ProductFilter>? Products { get; set; }
    }
}
