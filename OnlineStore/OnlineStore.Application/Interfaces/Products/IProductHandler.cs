using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces.Products;

public interface IProductHandler
{
    Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductDto?> GetProductAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> AddAsync(ProductDto dto, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(ProductDto dto, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(ProductDto dto, CancellationToken cancellationToken = default);
}