using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entitites
{
    [TestClass]
    public class StudentTests
    {
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _document = new Document("31865387185",
                                     EDocumentType.Cpf);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1",
                                   "1234",
                                   "Bairro Legal",
                                   "Gotham",
                                   "SP",
                                   "BR",
                                   "0909099");
            _student = new Student(new Name("Bruce", "Wayne"),
                                   _document,
                                   _email);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("122344",
                                            DateTime.Now,
                                            DateTime.Now.AddDays(5),
                                            10,
                                            10,
                                            "WAYNE CORP",
                                            _document,
                                            _address,
                                            _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("122344",
                                            DateTime.Now,
                                            DateTime.Now.AddDays(5),
                                            10,
                                            10,
                                            "WAYNE CORP",
                                            _document,
                                            _address,
                                            _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}