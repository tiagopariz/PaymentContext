using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barcode,
                             string boletoNumber,
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
            Barcode = barcode;
            BoletoNumber = boletoNumber;
        }

        public string Barcode { get; }
        public string BoletoNumber { get; }
    }
}