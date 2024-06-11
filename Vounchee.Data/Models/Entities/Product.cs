using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vounchee.Data.Models.Entities
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            Users = new HashSet<User>();
            Comments = new HashSet<Comment>();
            Discounts = new HashSet<Discount>();
            Ratings = new HashSet<Rating>();
            Tags = new HashSet<Tag>();
            Categories = new HashSet<Category>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductDiscountPrice { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [StringLength(1000)]
        public string ProductPolicy { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        public string ProductCodeImage { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; } 

        public virtual ICollection<Discount>? Discounts { get; set; }

        public virtual ICollection<Rating>? Ratings { get; set; } 

        public virtual ICollection<Tag> Tags { get; set; } 

        public virtual ICollection<Category> Categories { get; set; } 
    }
}
