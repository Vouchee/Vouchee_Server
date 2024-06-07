using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Application.DataAccessObjects.Base;
using Vouchee.Infrastructure.DataAccessObjects.Interfaces;
using Vouchee.Infrastructure.DataContext;

namespace Vouchee.Infrastructure.DataAccessObjects.Impls
{
    public class BaseDAO<TEntity> : IBaseDAO<TEntity> where TEntity : class
    {
        private static BaseDAO<TEntity> instance = null;
        private static readonly object InstanceLock = new object();

        private readonly VoucheeContext _context;
        private DbSet<TEntity> Table { get; set; }

        public BaseDAO(VoucheeContext context)
        {
            _context = context;
            Table = context.Set<TEntity>();
        }

        public static BaseDAO<TEntity> Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        VoucheeContext context = new VoucheeContext();
                        instance = new BaseDAO<TEntity>(context);
                    }
                    return instance;
                }
            }
        }

        public async Task<TEntity> FindAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().FirstOrDefault(predicate));
        }

        public async Task<IQueryable<TEntity>> FindAllAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().Where(predicate).AsQueryable());
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => Table.AsNoTracking());
        }

        public async Task<int> DeleteRangeAsync(IQueryable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> HardDeleteAsync(object key)
        {
            var entity = await Table.FindAsync(key);
            if (entity != null)
            {
                Table.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> HardDeleteIdAsync(object key)
        {
            return await HardDeleteAsync(key);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            return null;
		}

        public async Task<int> InsertRangeAsync(IQueryable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateByIdAsync(TEntity entity, object id)
        {
            var existingEntity = await Table.FindAsync(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                if (await _context.SaveChangesAsync() > 0)
                    return entity;
            }
            return null;
        }

        public async Task<int> UpdateRangeAsync(IQueryable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().Any(predicate));
        }

        public async Task<int> CountAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().Count(predicate));
        }

        public async Task<int> CountAsync()
        {
            return await Table.AsNoTracking().CountAsync();
        }

        public async Task<TEntity> FistOrDefaultAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().FirstOrDefault(predicate));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

		public async Task<bool> IsMinAsync(Func<TEntity, bool> predicate)
		{
            return await Task.Run(() => Table.Min(predicate));
		}

		public async Task<bool> IsMaxAsync(Func<TEntity, bool> predicate)
		{
			return await Task.Run(() => Table.Max(predicate));
		}

		public async Task<TEntity> GetMinAsync()
        {
            return await Table.AsNoTracking().OrderBy(e => e).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetMaxAsync()
        {
            return await Table.AsNoTracking().OrderByDescending(e => e).FirstOrDefaultAsync();
        }

        public async Task<bool> IsMaxAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var maxEntity = await Table.AsNoTracking().OrderByDescending(predicate).FirstOrDefaultAsync();
            return maxEntity != null;
        }

        public async Task<bool> IsMinAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var minEntity = await Table.AsNoTracking().OrderBy(predicate).FirstOrDefaultAsync();
            return minEntity != null;
        }

        public async Task<TEntity> GetMinAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().Where(predicate).OrderBy(e => e).FirstOrDefault());
        }

        public async Task<TEntity> GetMaxAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Table.AsNoTracking().Where(predicate).OrderByDescending(e => e).FirstOrDefault());
        }
    }
}