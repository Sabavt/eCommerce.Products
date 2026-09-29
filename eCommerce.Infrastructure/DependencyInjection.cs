using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option => option.UseMySQL(configuration.GetConnectionString("MySQLConnection")!));
        services.AddScoped<IProductsAdderRepository, ProductsAdderRepository>();
        services.AddScoped<IProductsDeleterRepository, ProductsDeleterRepository>();
        services.AddScoped<IProductsGetterRepository, ProductsGetterRepository>();
        services.AddScoped<IProductsUpdaterRepository, ProductsUpdaterRepository>();

        return services;
    } 
} 