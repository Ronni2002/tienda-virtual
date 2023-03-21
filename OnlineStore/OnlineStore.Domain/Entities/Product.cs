using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities;

public class Product: Entity
{
    public string Name { get; set; } = null!;
    public string Marca { get; set; } = null!;
    public ICollection<ProductPrice>? ProductByPrices { get; set; }
}