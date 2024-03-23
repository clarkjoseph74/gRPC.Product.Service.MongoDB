using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace gRPC.ProductService.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; } //Key
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
    public decimal Price { get; set; }

}
