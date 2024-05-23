using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Vouchee.Application.Common.Interfaces;
using Vouchee.Domain.Common;

namespace Vouchee.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _timeProvider;
    private readonly IUser _user;

    public AuditableEntityInterceptor(TimeProvider timeProvider, IUser user)
    {
        _timeProvider = timeProvider;
        _user = user;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntity(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    private void UpdateEntity(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity<Guid>>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                var utcNow = _timeProvider.GetUtcNow().DateTime;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _user.Id;
                    entry.Entity.Created = utcNow;
                } 
                entry.Entity.LastModifiedBy = _user.Id;
                entry.Entity.LastModified = utcNow;
            }
        }
    }
}
