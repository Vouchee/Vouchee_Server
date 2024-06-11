using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Data.Models.Entities
{
    [Table("Rating")]
    public partial class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RatingId { get; set; }

        public string RatingTitle { get; set; }

        public RatingType RatingType { get; set; }

        public string RatingContent { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
