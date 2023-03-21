using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductDto?> GetProductAsync(Guid id, CancellationToken cancellationToken = default);
}