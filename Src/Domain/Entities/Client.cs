namespace SistemaPOS.Src.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public Client(int id, string name, string username, string email, Address address, string phone, string website, Company company)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Address = address;
            Phone = phone;
            Website = website;
            Company = company;
        }

        public Client() { }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public Geo(string lat, string lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public Geo() { }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public Address(string street, string suite, string city, string zipcode, Geo geo)
        {
            Street = street;
            Suite = suite;
            City = city;
            Zipcode = zipcode;
            Geo = geo;
        }

        public Address() { }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public Company(string name, string catchPhrase, string bs)
        {
            Name = name;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }

        public Company() { }
    }
}
