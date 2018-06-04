namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName,
                                 string cardNumber,
                                 string lastTransactionName,
                                 DateTime paidDate,
                                 DateTime expireDate,
                                 decimal total,
                                 decimal totalPaid,
                                 string payer,
                                 string document,
                                 string address,
                                 string email)
            : base (paidDate,
                    expireDate,
                    total,
                    totalPaid,
                    payer,
                    document,
                    address,
                    email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionName = lastTransactionName;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionName { get; private set; }
    }
}