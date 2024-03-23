using gRPC.ProductService.Data;
using gRPC.ProductService.Repository;
using gRPC.ProductService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.Configure<DatabaseSettings>(op => builder.Configuration.GetSection("DatabaseSettings").Bind(op));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();

}
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<StoreService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
