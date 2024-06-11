using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Data.Models.Entities
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public CommentStatus CommentStatus { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
