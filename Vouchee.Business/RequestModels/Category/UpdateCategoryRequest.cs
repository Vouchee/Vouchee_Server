using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Category
{
    public class UpdateCategoryRequest
    {
        [Required]
        [StringLength(100)]
        public string CategoryTitle { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }
    }
}
