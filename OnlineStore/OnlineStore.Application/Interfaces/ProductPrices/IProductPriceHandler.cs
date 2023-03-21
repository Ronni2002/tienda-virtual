using OnlineStore.Application.Features.ProductPrices.Dto;

namespace OnlineStore.Application.Interfaces.ProductPrices;

public interface IProductPriceHandler
{
    Task<List<ProductPriceDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductPriceDto?> GetProductPriceAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> AddAsync(ProductPriceDto dto, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(ProductPriceDto dto, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(ProductPriceDto dto, CancellationToken cancellationToken = default);
}