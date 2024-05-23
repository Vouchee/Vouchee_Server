namespace Vouchee.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
