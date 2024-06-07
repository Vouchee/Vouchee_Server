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
	public class LocationDAO : BaseDAO<Location>, ILocationDAO
	{
		public LocationDAO(VoucheeContext context) : base(context)
		{
		}
	}
}
