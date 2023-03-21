using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repository;

public class ProductRepository: Repository<Product>, IProductRepository
{
    private readonly OnlineStoreContext _context;

    public ProductRepository(OnlineStoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products!.Select(Projections.GetProduct).ToListAsync(cancellationToken);
    }

    public async Task<ProductDto?> GetProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products!.Select(Projections.GetProduct)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}