using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;

namespace Vouchee.Infrastructure.DataAccessObjects.Interfaces
{
    public interface IBaseDAO<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Func<TEntity, bool> predicate);
        Task<IQueryable<TEntity>> FindAllAsync(Func<TEntity, bool> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<int> DeleteRangeAsync(IQueryable<TEntity> entities);
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> HardDeleteAsync(object key);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> HardDeleteIdAsync(object key);
        Task<TEntity> InsertAsync(TEntity entity); // Modified to return ID
        Task<int> InsertRangeAsync(IQueryable<TEntity> entities);
        Task<TEntity> UpdateByIdAsync(TEntity entity, object id);
        Task<int> UpdateRangeAsync(IQueryable<TEntity> entities);
        Task<bool> AnyAsync(Func<TEntity, bool> predicate);
        Task<int> CountAsync(Func<TEntity, bool> predicate);
        Task<int> CountAsync();
        Task<TEntity> FistOrDefaultAsync(Func<TEntity, bool> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
        Task<bool> IsMinAsync(Func<TEntity, bool> predicate);
        Task<bool> IsMaxAsync(Func<TEntity, bool> predicate);
        Task<TEntity> GetMinAsync();
        Task<TEntity> GetMaxAsync();
        Task<bool> IsMaxAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> IsMinAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetMinAsync(Func<TEntity, bool> predicate);
        Task<TEntity> GetMaxAsync(Func<TEntity, bool> predicate);
    }
}
