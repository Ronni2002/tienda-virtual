using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Common;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Extensions;

namespace OnlineStore.Infrastructure.Context;

public class OnlineStoreContext: DbContext
{
    private readonly ICurrentUser _currentUser;

    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductPrice>? ProductPrices { get; set; }

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options, ICurrentUser currentUser): base(options)
    {
        _currentUser = currentUser;
    }

    #region Configurations

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(Entity).IsAssignableFrom(type.ClrType))
                modelBuilder.SetSoftDeleteFilter(type.ClrType);
        }
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<Entity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.Created = DateTimeOffset.Now;
                    entity.Entity.CreateBy = _currentUser.GetCurrentUserId()!;
                    break;
                
                case EntityState.Modified:
                    entity.Entity.Updated = DateTimeOffset.Now;
                    entity.Entity.UpdateBy = _currentUser.GetCurrentUserId();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }

    #endregion
}