using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;
using Vouchee.Domain.Entities;

namespace Vouchee.Infrastructure.DataAccessObjects.Interfaces
{
	public interface ICategoryDAO : IBaseDAO<Category>
	{
	}
}
