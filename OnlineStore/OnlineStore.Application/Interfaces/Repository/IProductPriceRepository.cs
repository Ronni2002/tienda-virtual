using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces.Repository;

public interface IProductPriceRepository : IRepository<ProductPrice>
{
    Task<List<ProductPriceDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductPriceDto?> GetProductPriceAsync(Guid id, CancellationToken cancellationToken = default);
}