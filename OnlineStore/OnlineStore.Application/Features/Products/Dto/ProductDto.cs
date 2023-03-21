using OnlineStore.Application.Features.ProductPrices.Dto;

namespace OnlineStore.Application.Features.Products.Dto;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public List<ProductPriceDto>? ProductByPrices { get; set; }
}