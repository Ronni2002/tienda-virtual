using AutoMapper;
using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Application.Interfaces.ProductPrices;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductPrices.Handlers;

public class ProductPriceHandler: IProductPriceHandler
{
    private readonly IMapper _mapper;
    private readonly IProductPriceRepository _repository;
    private readonly IProductRepository _productRepository;

    public ProductPriceHandler(IMapper mapper, IProductPriceRepository repository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _productRepository = productRepository;
    }
    
    public Task<List<ProductPriceDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<ProductPriceDto?> GetProductPriceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _repository.GetProductPriceAsync(id, cancellationToken);
    }

    public async Task<int> AddAsync(ProductPriceDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(dto.ProductId, cancellationToken);

        if (product is null)
            return 0;
        
        var productPrice = _mapper.Map<ProductPrice>(dto);
        _repository.AddEntity(productPrice, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(ProductPriceDto dto, CancellationToken cancellationToken = default)
    {
        var productPrice = await _repository.GetByIdAsync(dto.Id, cancellationToken);
        
        if (productPrice is null)
            return 0;
        
        _mapper.Map(dto, productPrice);
        _repository.UpdateEntity(productPrice, cancellationToken);

        return await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(ProductPriceDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetByIdAsync(dto.Id, cancellationToken);
        
        if (product is null)
            return 0;
        
        _repository.DeleteEntity(product, cancellationToken);
        
        return await _repository.SaveChangesAsync(cancellationToken);
    }
}