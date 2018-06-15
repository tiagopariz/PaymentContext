using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName,
                    string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
            );
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}