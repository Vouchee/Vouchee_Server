using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Comment
{
    public class CreateCommentRequest
    {
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public CommentStatus CommentStatus { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid? CreatedBy { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
