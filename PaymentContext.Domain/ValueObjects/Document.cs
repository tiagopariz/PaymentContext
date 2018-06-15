using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number,
                        EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
            );
        }

        public string Number { get; }
        public EDocumentType Type { get; }

        private bool Validate()
        {
            switch (Type)
            {
                case EDocumentType.Cnpj when Number.Length == 14:
                    return true;
                case EDocumentType.Cpf when Number.Length == 11:
                    return true;
                default:
                    return false;
            }
        }
    }
}