using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;
using Vouchee.Infrastructure.DataAccessObjects.Impls;
using Vouchee.Infrastructure.DataAccessObjects.Interfaces;

namespace Vouchee.Infrastructure.Repositories.Impls
{
    public class BaseRepository<TEntity> : IBaseDAO<TEntity> where TEntity : class
    {
        public async Task<bool> AnyAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.CountAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.DeleteRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> FindAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.FindAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.FindAllAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.FindAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetWhereAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> HardDeleteAsync(object key)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.HardDeleteAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> HardDeleteIdAsync(object key)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.HardDeleteIdAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> InsertRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.InsertRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> UpdateByIdAsync(TEntity entity, object id)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.UpdateByIdAsync(entity, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.UpdateRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsMinAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.IsMinAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsMaxAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.IsMaxAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetMinAsync()
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetMinAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetMaxAsync()
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetMaxAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsMaxAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.IsMaxAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsMinAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.IsMinAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetMinAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetMinAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetMaxAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.GetMaxAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> FistOrDefaultAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await BaseDAO<TEntity>.Instance.FistOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
