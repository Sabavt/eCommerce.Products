using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation; 

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

        app.MapGet("/search/{productName:alpha}", async (IProductsGetterService productsGetterService, string productName) =>
        {
            var lowerSearchTerm = productName.ToLower();

            var product = await productsGetterService.GetProductByCondition(t =>
                t.ProductName.ToLower().Contains(lowerSearchTerm) ||
                (t.Category != null && t.Category.ToLower().Contains(lowerSearchTerm))
            );
            return Results.Ok(product);
        });

        app.MapPost("/add", async (IProductsAdderService productsAdderService, ProductDTO productAddRequest, IValidator<ProductDTO> validator) =>
        {
            var result = await validator.ValidateAsync(productAddRequest);
            if(!result.IsValid)
            {
                Dictionary<string, string[]> errors = result.Errors.GroupBy(t => t.PropertyName).ToDictionary(l => l.Key, l => l.Select(err => err.ErrorMessage).ToArray());
                return Results.ValidationProblem(errors);
            }
            var products = await productsAdderService.AddProduct(productAddRequest);
            return Results.Ok(products);
        });

        app.MapPut("/update", async (IProductsUpdaterService productsUpdaterService, ProductDTO productAddRequest, IValidator<ProductDTO> validator) =>
        {
            var result = await validator.ValidateAsync(productAddRequest);
            if (!result.IsValid)
            {
                Dictionary<string, string[]> errors = result.Errors.GroupBy(t => t.PropertyName).ToDictionary(l => l.Key, l => l.Select(err => err.ErrorMessage).ToArray());
                return Results.ValidationProblem(errors);
            }
            var products = await productsUpdaterService.UpdateProduct(productAddRequest);
            return Results.Ok(products);
        });

        app.MapDelete("/delete/{productID:guid}", async (IProductsDeleterService productsDeleterService, Guid productID) =>
        { 
            var isDeleted = await productsDeleterService.DeleteProduct(productID);
            if (isDeleted)
                return Results.Ok(true);
            else
                return Results.Problem("Error during deleting product");
        });

        return app;
    }
}