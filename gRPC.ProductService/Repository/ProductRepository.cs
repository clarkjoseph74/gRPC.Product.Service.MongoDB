using gRPC.ProductService.Data;
using gRPC.ProductService.Entities;
using MongoDB.Driver;

namespace gRPC.ProductService.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IApplicationDbContext _context;

    public ProductRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> DeleteProduct(Product product)
    {
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(Builders<Product>.Filter.Eq(p => p.ID, product.ID));
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        DeleteResult deleteResult = await _context.Products.DeleteOneAsync(Builders<Product>.Filter.Eq(p => p.ID, id));
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.Find(x => true).ToListAsync();
    }

    public async Task<Product> GetByID(string id)
    {
        return await _context.Products.Find(p => p.ID == id).FirstOrDefaultAsync();
    }

    public Task<IEnumerable<Product>> Search()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _context.Products.ReplaceOneAsync(p => p.ID == product.ID, replacement: product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}
