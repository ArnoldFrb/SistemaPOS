using System.Text.Json.Serialization;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Models
{
    public record ProductResponse(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("price")] double Price,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("category")] string Category,
        [property: JsonPropertyName("image")] string Image,
        [property: JsonPropertyName("rating")] RatingResponse Rating
    )
    {
        public Product ToEntity() => new(Id, Title, Price, Description, Category, Image, Rating.ToEntity());
    }

    public record RatingResponse(
        [property: JsonPropertyName("rate")] double Rate,
        [property: JsonPropertyName("count")] int Count
    )
    {
        public Rating ToEntity() => new(Rate, Count);
    }

}
