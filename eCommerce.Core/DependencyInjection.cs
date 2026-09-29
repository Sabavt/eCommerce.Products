using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Mappers;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Product>(); 
        services.AddAutoMapper(p => {
            p.AddProfile(new ProductDTOMappingProfile());
            p.AddProfile(new ProductMappingProfile());
        });
        services.AddScoped<IProductsAdderService, ProductsAdderService>();
        services.AddScoped<IProductsUpdaterService, ProductsUpdaterService>();
        services.AddScoped<IProductsDeleterService, ProductsDeleterService>();
        services.AddScoped<IProductsGetterService, ProductsGetterService>();

        return services;
    } 
} 