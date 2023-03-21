using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Domain.Common;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repository;

public class Repository<T>: IRepository<T> where T: Entity
{
    private readonly OnlineStoreContext _context;
    public Repository(OnlineStoreContext context)
    {
        _context = context;
    }
    
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void AddEntity(T entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _context.Add(entity);
    }
    
    public void AddRangeEntity(List<T> entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _context.AddRange(entity);
    }

    public void UpdateEntity(T entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void DeleteEntity(T entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        entity.DeleteToken = Guid.NewGuid();
        
        cancellationToken.ThrowIfCancellationRequested();
        _context.Set<T>().Update(entity);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}