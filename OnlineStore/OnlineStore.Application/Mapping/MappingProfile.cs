using AutoMapper;
using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<ProductPriceDto, ProductPrice>();

    }
}