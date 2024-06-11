using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vounchee.Data.Models.Constants.Enum;

namespace Vounchee.Data.Models.Entities
{
    [Table("Promotion")]
    public class Promotion
    {
        public Promotion()
        {
            Shops = new HashSet<Shop>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromotionId { get; set; }

        [Required]
        [StringLength(100)]
        public string PromotionTitle { get; set; }

        [StringLength(500)]
        public string PromotionDetails { get; set; }

        [Required]
        [StringLength(50)]
        public string PromotionCode { get; set; }

        [Required]
        public PromotionStatus PromotionStatus { get; set; }

        [Required]
        public PromotionType PromotionType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public virtual ICollection<Shop>? Shops { get; set; }
    }
}
