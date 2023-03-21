using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Interfaces.Repository;
using OnlineStore.Infrastructure.Context;
using OnlineStore.Infrastructure.Repository;

namespace OnlineStore.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        return service
                .AddDbContext<OnlineStoreContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductPriceRepository, ProductPriceRepository>();
    }
}