namespace SistemaPOS.Src.Domain.Entities
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public OrderDetail(int productId, decimal unitPrice, string productName, string pictureUrl, int quantity, decimal discount)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Quantity = quantity;
            Discount = discount;
        }

        public OrderDetail()
        {
        }

        public decimal Total => Quantity * UnitPrice;

        public override string ToString()
        {
            return String.Format("Product Id: {0}, Quantity: {1}", ProductId, Quantity);
        }
    }
}
