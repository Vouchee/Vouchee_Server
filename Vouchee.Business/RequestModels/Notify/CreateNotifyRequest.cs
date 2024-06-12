using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Notify
{
    public class CreateNotifyRequest
    {
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public Guid? UserId { get; set; }
    }
}
