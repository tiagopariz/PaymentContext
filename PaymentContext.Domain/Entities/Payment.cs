using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Notifiable
    {
        protected Payment(DateTime paidDate,
                       DateTime expireDate,
                       decimal total,
                       decimal totalPaid,
                       string payer,
                       Document document,
                       Address address,
                       Email email)
        {
            Number = Guid.NewGuid()
                         .ToString()
                         .Replace("-", "")
                         .Substring(0, 10)
                         .ToUpper();

            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.Total", "O valor pago é menor que o total")
            );
        }

        public string Number { get; }
        public DateTime PaidDate { get; }
        public DateTime ExpireDate { get; }
        public decimal Total { get; }
        public decimal TotalPaid { get; }
        public string Payer { get; }
        public Document Document { get; }
        public Address Address { get; }
        public Email Email { get; }
    }
}