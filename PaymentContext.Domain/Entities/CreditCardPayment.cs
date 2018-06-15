using PaymentContext.Domain.ValueObjects;
using System;

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
                                 Document document,
                                 Address address,
                                 Email email)
            : base(paidDate,
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

        public string CardHolderName { get; }
        public string CardNumber { get; }
        public string LastTransactionName { get; }
    }
}