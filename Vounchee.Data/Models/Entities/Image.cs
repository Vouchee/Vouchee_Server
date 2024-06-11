using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vounchee.Data.Models.Constants.Enum;

namespace Vounchee.Data.Models.Entities
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ImageId { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        public ImageType ImageType { get; set; }

        public Guid? ShopId { get; set; }

        public virtual Shop? Shop { get; set; }
    }
}
