using AutoMapper;
using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Application.Interfaces.Products;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Products.Handlers;

public class ProductHandler: IProductHandler
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductHandler(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<ProductDto?> GetProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.GetProductAsync(id, cancellationToken);
    }

    public Task<int> AddAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = _mapper.Map<Product>(dto);
        _repository.AddEntity(product, cancellationToken);

        return _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(dto.Id, cancellationToken);
        
        if (product is null)
            return 0;
        
        _mapper.Map(dto, product);
        _repository.UpdateEntity(product, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(dto.Id, cancellationToken);
        
        if (product is null)
            return 0;
        
        _repository.DeleteEntity(product, cancellationToken);
        
        return await _repository.SaveChangesAsync(cancellationToken);
    }
}