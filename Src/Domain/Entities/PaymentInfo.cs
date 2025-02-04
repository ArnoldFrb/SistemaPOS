namespace SistemaPOS.Src.Domain.Entities
{
    public class PaymentInfo
    {
        public int CardTypeId { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public DateTime CardExpiration { get; set; }

        public string CardSecurityNumber { get; set; }

        public PaymentInfo(int cardTypeId, string cardNumber, string cardHolderName, DateTime cardExpiration, string cardSecurityNumber)
        {
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CardExpiration = cardExpiration;
            CardSecurityNumber = cardSecurityNumber;
        }

        public PaymentInfo()
        {
        }
    }
}
