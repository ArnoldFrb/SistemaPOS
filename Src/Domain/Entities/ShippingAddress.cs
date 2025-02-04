namespace SistemaPOS.Src.Domain.Entities
{
    public class ShippingAddress
    {
        public string ShippingCity { get; set; }

        public string ShippingStreet { get; set; }

        public string ShippingState { get; set; }

        public string ShippingCountry { get; set; }

        public string ShippingZipCode { get; set; }

        public ShippingAddress(string shippingCity, string shippingStreet, string shippingState, string shippingCountry, string shippingZipCode)
        {
            ShippingCity = shippingCity;
            ShippingStreet = shippingStreet;
            ShippingState = shippingState;
            ShippingCountry = shippingCountry;
            ShippingZipCode = shippingZipCode;
        }

        public ShippingAddress()
        {
        }
    }
}
