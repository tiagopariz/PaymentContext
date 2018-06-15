using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Notifiable
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name,
                       Document document,
                       Email email,
                       Address address = null)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; }
        public Document Document { get; }
        public Email Email { get; }
        public Address Address { get; }
        public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive,
                         "Student.Subscriptions",
                         "Você já tem uma assinatura ativa")
                .AreEquals(0,
                          subscription.Payments.Count,
                          "Student.Subscription.Payments",
                          "Esta assinatura não possui pagamentos")
            );
        }
    }
}