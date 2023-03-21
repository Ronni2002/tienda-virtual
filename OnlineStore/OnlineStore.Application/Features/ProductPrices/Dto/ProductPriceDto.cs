namespace OnlineStore.Application.Features.ProductPrices.Dto;

public class ProductPriceDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Color { get; set; } = null!;
    public decimal Cost { get; set; }
}