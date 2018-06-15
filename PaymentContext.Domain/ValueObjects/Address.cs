using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street,
                       string number,
                       string neighborhood,
                       string city,
                       string state,
                       string country,
                       string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "A rua deve conter ao menos 3 caracteres")
            );
        }

        public string Street { get; }
        public string Number { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
    }
}