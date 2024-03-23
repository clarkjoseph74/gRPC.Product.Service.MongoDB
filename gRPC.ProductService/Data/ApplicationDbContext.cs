using gRPC.ProductService.Entities;
using gRPC.ProductService.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace gRPC.ProductService.Data;

public class ApplicationDbContext : IApplicationDbContext
{
    private readonly DatabaseSettings _settings;
    public IMongoCollection<Product> Products { get; }
    public ApplicationDbContext(IOptions<DatabaseSettings> settings)
    {
        _settings = settings.Value;
        var client = new MongoClient(_settings.ConnectionString);
        var database = client.GetDatabase(_settings.DatabaseName);
        Products = database.GetCollection<Product>(_settings.CollectionName);

        Products.SeedData();
    }
}
