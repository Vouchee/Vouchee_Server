using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vounchee.Data.Models.Entities
{
    public class Tag
    {
        public Tag()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TagId { get; set; }

        [Required]
        [StringLength(100)]
        public string TagName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
