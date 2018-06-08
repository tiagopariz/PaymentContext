using PaymentContext.Shared.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName,
                    string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", 
                                "Nome inválido");

            if (string.IsNullOrEmpty(firstName))
                AddNotification("Name.LasName", 
                                "Sobrenome inválido");

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
            );

            // Code contracts : Projeto MS
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}