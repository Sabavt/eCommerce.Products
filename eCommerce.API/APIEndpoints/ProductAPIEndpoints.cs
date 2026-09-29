using eCommerce.Core.ServiceContracts; 

namespace eCommerce.API.APIEndpoints;

public static class ProductAPIEndpoints
{
    public static IEndpointRouteBuilder MapProductsAPI(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (IProductsGetterService productsGetterService) =>
        {
            var products = await productsGetterService.GetProducts();
            return Results.Ok(products); 
        });







        return app;
    }
}