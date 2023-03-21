using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities;

public class ProductPrice: Entity
{
    public Guid ProductId { get; set; }
    public string Color { get; set; } = null!;
    public decimal Cost { get; set; }
    public Product Product { get; set; } = null!;
}