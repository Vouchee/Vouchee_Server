using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vouchee.Data.Models.Constants.Enum;

namespace Vouchee.Data.Models.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }

        public string TransactionDetail { get; set; }

        public DateTime? TransactionDateTime { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public TransactionStatusEnum TransactionStatusEnum { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
