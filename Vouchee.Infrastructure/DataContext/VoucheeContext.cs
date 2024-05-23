using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Vouchee.Application.Common.Interfaces;
using Vouchee.Common.Constants;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.Helpers;

namespace Vouchee.Infrastructure.DataContext;

public class VoucheeContext : IdentityDbContext<User, Role,
    Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>, IApplicationDbContext, IReadOnlyApplicationDbContext
{
    public VoucheeContext()
    {
        
    }

    public VoucheeContext(DbContextOptions<VoucheeContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlServer(DataAccessHelper.GetConnectionString());
        if (ApplicationEnvironment.IsDevelopment())
            optionsBuilder.EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine);
    }

    public IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    public IQueryable<TEntity> CreateReadOnlySet<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>().AsNoTracking();
    }
    
}