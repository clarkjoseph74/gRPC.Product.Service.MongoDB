using gRPC.ProductService.Repository;
using Grpc.Core;

namespace gRPC.ProductService.Services;
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    private readonly IProductRepository _repo;
    public GreeterService(ILogger<GreeterService> logger, IProductRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public override Task<NumbersResponse> SayHello(NumbersRequest request, ServerCallContext context)
    {
        return Task.FromResult(new NumbersResponse
        {
            Result = request.NumberOne + request.NumberTwo
        });
    }

}
