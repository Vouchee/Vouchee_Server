using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.DataContext;

namespace Vouchee.Infrastructure.DataAccessObjects.Impls
{
    public class CategoryDAO : BaseDAO<Category>
    {
        public CategoryDAO(VoucheeContext context) : base(context)
        {
        }
    }
}
