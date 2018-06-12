using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Shared;
using PaymentContext.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Student : Notifiable
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name,
                       Document document,
                       Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions
        { 
            get
            {
                return _subscriptions.ToArray();
            } 
        }

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