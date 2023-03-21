using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repository;

public class ProductPriceRepository: Repository<ProductPrice>, IProductPriceRepository
{
    private readonly OnlineStoreContext _context;

    public ProductPriceRepository(OnlineStoreContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<ProductPriceDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ProductPrices!
            .Select(Projections.GetProductPrice).ToListAsync(cancellationToken);
    }
    
    public async Task<ProductPriceDto?> GetProductPriceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ProductPrices!.Select(Projections.GetProductPrice)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}