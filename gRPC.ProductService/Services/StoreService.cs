using gRPC.ProductService.Entities;
using gRPC.ProductService.Protos;
using gRPC.ProductService.Repository;
using Grpc.Core;
using System.Text.Json;

namespace gRPC.ProductService.Services;

public class StoreService : ProductStore.ProductStoreBase
{

    private readonly ILogger<GreeterService> _logger;
    private readonly IProductRepository _repo;
    public StoreService(ILogger<GreeterService> logger, IProductRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }
    public override async Task<PrdouctsResponse> GetProducts(Empty request, ServerCallContext context)
    {
        PrdouctsResponse result = new PrdouctsResponse();
        var prods = await _repo.GetAll();
        foreach (var prod in prods)
        {
            result.Products.Add(new ProductMessage
            {
                Id = prod.ID,
                Name = prod.Name,
                Category = prod.Category,
                Description = prod.Description,
                ImageFile = prod.ImageFile,
                Price = double.Parse(prod.Price.ToString()),
                Summary = prod.Summary,
            });
        };
        _logger.LogInformation(JsonSerializer.Serialize(result));
        return await Task.FromResult(result);
    }


    public override async Task<ProductMessage> AddProducts(ProductMessage request, ServerCallContext context)
    {
        var product = new Product
        {
            ID = request.Id,
            Name = request.Name,
            Category = request.Category,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Price = (decimal)request.Price.Value,
            Summary = request.Summary,
        };
        var res = _repo.CreateProduct(product);
        return await Task.FromResult(request);
    }

    public override async Task<ProductMessage> UpdateProducts(ProductMessage request, ServerCallContext context)
    {
        var product = new Product
        {
            ID = request.Id,
            Name = request.Name,
            Category = request.Category,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Price = (decimal)request.Price.Value,
            Summary = request.Summary,
        };
        var res = await _repo.UpdateProduct(product);
        return await Task.FromResult(res ? request : new ProductMessage { });
    }

    public override async Task<ProductMessage> DeleteProducts(DeleteRequest request, ServerCallContext context)
    {
        var product = await _repo.GetByID(request.Id);
        var message = new ProductMessage
        {
            Id = product.ID,
            Name = product.Name,
            Category = product.Category,
            Description = product.Description,
            ImageFile = product.ImageFile,
            Price = double.Parse(product.Price.ToString()),
            Summary = product.Summary,
        };
        var res = await _repo.DeleteProduct(request.Id);
        return res ? message : new ProductMessage { };
    }
}
