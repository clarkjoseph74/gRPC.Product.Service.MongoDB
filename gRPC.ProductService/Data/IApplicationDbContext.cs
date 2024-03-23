using gRPC.ProductService.Entities;
using MongoDB.Driver;

namespace gRPC.ProductService.Data;

public interface IApplicationDbContext
{
    IMongoCollection<Product> Products { get; }
}
