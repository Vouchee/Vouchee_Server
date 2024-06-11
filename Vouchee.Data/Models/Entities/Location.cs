using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Data.Models.Entities
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationId { get; set; }

        [StringLength(100)]
        public string LocationCity { get; set; }

        [StringLength(100)]
        public string LocationDistrict { get; set; }

        [StringLength(100)]
        public string LocationWard { get; set; }

        [StringLength(200)]
        public string LocationStreet { get; set; }

        [StringLength(500)]
        public string LocationDetails { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
