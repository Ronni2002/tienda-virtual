namespace OnlineStore.Application.Interfaces.Repository;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void AddEntity(T entity, CancellationToken cancellationToken = default);
    void AddRangeEntity(List<T> entity, CancellationToken cancellationToken = default);
    void UpdateEntity(T entity, CancellationToken cancellationToken = default);
    void DeleteEntity(T entity, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}