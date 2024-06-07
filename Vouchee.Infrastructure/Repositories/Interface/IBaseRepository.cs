using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;
using Vouchee.Infrastructure.DataAccessObjects.Interfaces;

namespace Vouchee.Infrastructure.Repositories.Interface
{
    public interface IBaseRepository<TEntity> : IBaseDAO<TEntity> where TEntity : class
    {
    }
}
