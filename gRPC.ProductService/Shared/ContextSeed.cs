
using gRPC.ProductService.Entities;
using MongoDB.Driver;

namespace gRPC.ProductService.Shared;

public static class ContextSeed
{
    public static void SeedData(this IMongoCollection<Product> collection)
    {
        bool existData = collection.Find(p => true).Any();
        if (!existData)
        {
            collection.InsertMany(GetPreConfigedProducts());
        }
    }

    private static IEnumerable<Product> GetPreConfigedProducts()
    {
        return new List<Product> {
            new Product {

                Name = "IPhone 13",
                Category = "Mobile Phone",
                Description = "Write description about iphone 13",
                ImageFile = "https://etisal-storeapi.witheldokan.com/storage/uploads/iphone-13-blue-select-2021_1_1_1.png",
                Price = 33000
            },
             new Product {

                Name = "IPhone 13",
                Category = "Mobile Phone",
                Description = "Write description about iphone 13",
                ImageFile = "https://etisal-storeapi.witheldokan.com/storage/uploads/iphone-13-blue-select-2021_1_1_1.png",
                Price = 33000
            },
              new Product {

                Name = "IPhone 13",
                Category = "Mobile Phone",
                Description = "Write description about iphone 13",
                ImageFile = "https://etisal-storeapi.witheldokan.com/storage/uploads/iphone-13-blue-select-2021_1_1_1.png",
                Price = 33000
            },
               new Product {

                Name = "IPhone 13",
                Category = "Mobile Phone",
                Description = "Write description about iphone 13",
                ImageFile = "https://etisal-storeapi.witheldokan.com/storage/uploads/iphone-13-blue-select-2021_1_1_1.png",
                Price = 33000
            },
                new Product {

                Name = "IPhone 13",
                Category = "Mobile Phone",
                Description = "Write description about iphone 13",
                ImageFile = "https://etisal-storeapi.witheldokan.com/storage/uploads/iphone-13-blue-select-2021_1_1_1.png",
                Price = 33000
            },
        };
    }
}
