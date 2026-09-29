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

        app.MapGet("/search/{productID:guid}", async (IProductsGetterService productsGetterService, Guid productID) =>
        {
            var product = await productsGetterService.GetProductByCondition(t => t.ProductID == productID);
            return Results.Ok(product);
        });





        return app;
    }
}