using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.Repositories.Interface
{
	public interface ITransactionRepository : IBaseRepository<Transaction>
	{
	}
}
