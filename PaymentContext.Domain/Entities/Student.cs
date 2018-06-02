using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public ClassName(string firstName,
                         string lastName,
                         string Document,
                         string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = Document;
            Email = email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public List<Subscription> Subscriptions { get; private set; }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura, cancela

            // Cancela todas as outras assinaturas e coloca esta
            // como principal
            foreach (var sub in Subscriptions)
            {
                sub.Active = false;
                Subscriptions.Add(sub);
            }
        }
    }
}