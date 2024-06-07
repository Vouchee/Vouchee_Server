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
	public class ShopDAO : BaseDAO<Shop>, IShopDAO
	{
		public ShopDAO(VoucheeContext context) : base(context)
		{
		}
	}
}