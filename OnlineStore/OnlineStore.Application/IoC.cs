using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Features.ProductPrices.Handlers;
using OnlineStore.Application.Features.Products.Handlers;
using OnlineStore.Application.Interfaces.ProductPrices;
using OnlineStore.Application.Interfaces.Products;

namespace OnlineStore.Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddTransient<IProductHandler, ProductHandler>()
            .AddTransient<IProductPriceHandler, ProductPriceHandler>();
    }
}