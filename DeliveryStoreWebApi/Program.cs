//using DeliveryStoreDomain.Interfaces;
//using DeliveryStoreInfra.Repositories;

using DeliveryStoreInfra;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreInfra.Repositories;
using DeliveryStoreServices.Interfaces;
using DeliveryStoreServices.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connection = builder.Configuration["ConexaoSqlite:SqliteConnectionString"];
//builder.Services.AddDbContext<DeliveryContext>(options => options.UseSqlite(connection));

builder.Services.AddSingleton<DeliveryContext>();

//IoC Services
builder.Services.AddScoped<IProductService, ProductService>();


//IoC Repo
builder.Services.AddScoped<IProductRepository, ProductRepository>();



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
