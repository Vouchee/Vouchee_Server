namespace Vouchee.Application.Common.Interfaces;

public interface IReadOnlyApplicationDbContext
{
    IQueryable<TEntity> CreateReadOnlySet<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
