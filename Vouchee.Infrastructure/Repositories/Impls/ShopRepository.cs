using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.Repositories.Interface;

namespace Vouchee.Infrastructure.Repositories.Impls
{
	public class ShopRepository : BaseRepository<Shop>, IShopRepository
	{
	}
}
