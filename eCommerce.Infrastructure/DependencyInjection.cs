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
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        connectionString
            .Replace("$MYSQL_HOST", 
            Environment.GetEnvironmentVariable("MYSQL_HOST"))
            .Replace("$MYSQL_PASSWORD",
            Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

        services.AddDbContext<ApplicationDbContext>(option => option.UseMySQL());
        services.AddScoped<IProductsAdderRepository, ProductsAdderRepository>();
        services.AddScoped<IProductsDeleterRepository, ProductsDeleterRepository>();
        services.AddScoped<IProductsGetterRepository, ProductsGetterRepository>();
        services.AddScoped<IProductsUpdaterRepository, ProductsUpdaterRepository>();

        return services;
    } 
} 