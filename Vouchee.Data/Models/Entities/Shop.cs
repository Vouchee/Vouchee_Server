using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Data.Models.Entities
{
    [Table("Shop")]
    public class Shop
    {
        public Shop()
        {
            Images = new HashSet<Image>();
            Locations = new HashSet<Location>();
            Promotions = new HashSet<Promotion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ShopId { get; set; }

        [Required]
        [StringLength(100)]
        public string ShopName { get; set; }

        [StringLength(200)]
        public string ShopTitle { get; set; }

        public string ShopDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PercentShow { get; set; }

        public int ResponsibilityScore { get; set; }

        [Required]
        public ShopStatusEnum ShopStatus { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Image>? Images { get; set; }

        public virtual ICollection<Location>? Locations { get; set; }

        public virtual ICollection<Promotion>? Promotions { get; set; }
    }
}
