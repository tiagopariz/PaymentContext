using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Commands;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    // Red, Green, Refactor

    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), 
                                                  new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName= "Wayne";
            command.Document= "99999999999";
            command.Email= "hello@balta.io2";
            command.Barcode= "123456789";
            command.BoletoNumber= "123454987";
            command.PaymentNumber= "123121";
            command.PaidDate= DateTime.Now;
            command.ExpireDate= DateTime.Now.AddMonths(1);
            command.Total= 60;
            command.TotalPaid= 60   ;
            command.Payer= " WAYNE CORP";
            command.PayerDocument= "12345678911";
            command.PayerDocumentType= EDocumentType.CPF;
            command.Street= "Rua A";
            command.Number= "189";
            command.Neighborhood= "Hin";
            command.City= "Gothan";
            command.State= "AS";
            command.Country= "US";
            command.ZipCode= "12345666";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }        
    }
}