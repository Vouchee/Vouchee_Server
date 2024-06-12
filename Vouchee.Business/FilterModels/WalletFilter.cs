using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.FilterModels
{
    public class WalletFilter
    {
        public Guid? WalletId { get; set; }

        public decimal? WalletAmount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public Guid? UserId { get; set; }

        public virtual UserFilter? User { get; set; }
    }
}
