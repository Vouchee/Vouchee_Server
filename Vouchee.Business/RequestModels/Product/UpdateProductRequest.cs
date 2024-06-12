using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Product
{
    public class UpdateProductRequest
    {
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

        public DateTime UpdatedDate { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
