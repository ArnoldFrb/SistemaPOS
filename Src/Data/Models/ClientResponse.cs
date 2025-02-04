using System.Text.Json.Serialization;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Data.Models
{
    public record ClientResponse(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("email")] string Email,
        [property: JsonPropertyName("address")] AddressResponse Address,
        [property: JsonPropertyName("phone")] string Phone,
        [property: JsonPropertyName("website")] string Website,
        [property: JsonPropertyName("company")] CompanyResponse Company
    )
    {
        public Client ToEntity() => new(Id, Name, Username, Email, Address.ToEntity(), Phone, Website, Company.ToEntity());
    }

    public record AddressResponse(
        [property: JsonPropertyName("street")] string Street,
        [property: JsonPropertyName("suite")] string Suite,
        [property: JsonPropertyName("city")] string City,
        [property: JsonPropertyName("zipcode")] string Zipcode,
        [property: JsonPropertyName("geo")] GeoResponse Geo
    )
    {
        public Address ToEntity() => new(Street, Suite, City, Zipcode, Geo.ToEntity());
    }

    public record CompanyResponse(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("catchPhrase")] string CatchPhrase,
        [property: JsonPropertyName("bs")] string Bs
    )
    {
        public Company ToEntity() => new(Name, CatchPhrase, Bs);
    }

    public record GeoResponse(
        [property: JsonPropertyName("lat")] string Lat,
        [property: JsonPropertyName("lng")] string Lng
    )
    {
        public Geo ToEntity() => new(Lat, Lng);
    }
}
