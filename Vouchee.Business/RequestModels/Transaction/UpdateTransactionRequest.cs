using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.RequestModels.Transaction
{
    public class UpdateTransactionRequest
    {
        public string TransactionDetail { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TransactionDateTime { get; set; } = DateTime.Now;

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public TransactionStatusEnum TransactionStatusEnum { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
