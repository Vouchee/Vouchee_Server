using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.RequestModels.Wallet
{
    public class UpdateWalletRequest
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WalletAmount { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
