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
	public class ShopPromotionDAO : BaseDAO<ShopPromotion>, IShopPromotionDAO
	{
		public ShopPromotionDAO(VoucheeContext context) : base(context)
		{
		}
	}
}