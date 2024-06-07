using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.DataAccessObjects.Interfaces;
using Vouchee.Infrastructure.DataContext;

namespace Vouchee.Infrastructure.DataAccessObjects.Impls
{
	public class ProductTagDAO : BaseDAO<ProductTag>, IProductTagDAO
	{
		public ProductTagDAO(VoucheeContext context) : base(context)
		{
		}
	}
}