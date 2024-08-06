using DeliveryStoreDomain.ValueObject;
using DeliveryStoreInfra;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreInfra.Repositories;
using DeliveryStoreServices.External;
using DeliveryStoreServices.Fees;
using DeliveryStoreServices.Interfaces;
using DeliveryStoreServices.Product;
using DeliveryStoreServices.Sales;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DeliveryContext>();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.Configure<CompanyValueObject>(builder.Configuration.GetSection("Company"));
builder.Services.Configure<ShippingCostValueObject>(builder.Configuration.GetSection("ShippingCost"));

//IoC Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShippingCalculationService, ShippingCalculationService>();
builder.Services.AddScoped<IClientWebApiService, ClientWebApiService>();
builder.Services.AddScoped<ISaleService, SaleService>();

//IoC Repo
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ISalesProductItensRepository, SalesProductItensRepository>();


var app = builder.Build();


// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DeliveryContext>();
    
    await context.Init();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
