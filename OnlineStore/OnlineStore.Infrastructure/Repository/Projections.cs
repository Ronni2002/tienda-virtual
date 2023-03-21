using System.Linq.Expressions;
using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Repository;

public static class Projections
{
    public static Expression<Func<Product, ProductDto>> GetProduct { get; } =
        product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Marca = product.Marca,
            ProductByPrices = product.ProductByPrices!.Select(pp => new ProductPriceDto
            {
                Id = pp.Id,
                Color = pp.Color,
                Cost = pp.Cost,
                ProductId = pp.ProductId
            }).ToList()
        };

    public static Expression<Func<ProductPrice, ProductPriceDto>> GetProductPrice { get; } =
        productPrice => new ProductPriceDto
        {
            Id = productPrice.Id,
            Color = productPrice.Color,
            Cost = productPrice.Cost,
            ProductId = productPrice.ProductId
        };
}