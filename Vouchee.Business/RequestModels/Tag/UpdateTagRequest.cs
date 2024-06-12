using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Tag
{
    public class UpdateTagRequest
    {
        [Required]
        [StringLength(100)]
        public string TagName { get; set; }
    }
}
