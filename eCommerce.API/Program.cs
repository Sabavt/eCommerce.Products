using eCommerce.API.APIEndpoints;
using eCommerce.API.Middlewares;
using eCommerce.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration); 
builder.Services.AddServices();

var app = builder.Build();
app.UseExceptionMiddleware(); 
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapGroup("api/products").MapProductsAPI();

app.Run(); 