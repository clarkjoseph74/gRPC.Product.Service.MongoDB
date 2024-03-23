

using gRPC.ProductService.Entities;

namespace gRPC.ProductService.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetByID(string id);
    Task<IEnumerable<Product>> Search();
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Product product);
    Task<bool> DeleteProduct(string id);

}
