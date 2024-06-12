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
    public class CommentFilter
    {
        public Guid? CommentId { get; set; }

        public string? Description { get; set; }

        public CommentStatus? CommentStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid? UserId { get; set; }

        public virtual UserFilter? User { get; set; }

        public Guid? ProductId { get; set; }

        public virtual ProductFilter? Product { get; set; }
    }
}
