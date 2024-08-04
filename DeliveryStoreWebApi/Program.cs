

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connection = builder.Configuration["ConexaoSqlite:SqliteConnectionString"];

//builder.Services.AddDbContext<DeliveryContext>(options => options.UseSqlite(connection));



//IoC
//builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.AddTransient<IShippingCalculation, ShippingCalculation>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
