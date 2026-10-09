using eCommerce.API.APIEndpoints;
using eCommerce.API.Middlewares;
using eCommerce.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration); 
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(plc => plc.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseExceptionMiddleware(); 
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(); 
app.MapGroup("api/products").MapProductsAPI();

app.Run(); 