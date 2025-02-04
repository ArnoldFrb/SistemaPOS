namespace SistemaPOS.Src.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal Total { get; set; }

        public Order(int id, OrderStatus orderStatus, ShippingAddress shippingAddress, PaymentInfo paymentInfo, List<OrderDetail> orderDetails, decimal total)
        {
            Id = id;
            OrderDate = DateTime.Now;
            OrderStatus = orderStatus;
            ShippingAddress = shippingAddress;
            PaymentInfo = paymentInfo;
            OrderDetails = orderDetails;
            Total = total;
        }

        public Order()
        {
        }
    }

    public enum OrderStatus
    {
        Submitted,
        Paid,
        Shipped
    }
}
