using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Helpers;
using Vouchee.Data.Models.Entities;
using Vouchee.Data.Repositories.Impls;

namespace Vouchee.Data.Repositories.Repos
{
    public class TransactionRepo : BaseRepo<Transaction>, ITransactionRepo
    {
        private readonly VoucheeContext _context;

        public TransactionRepo(VoucheeContext context) : base(context)
        {
            _context = context;
        }
    }
}
