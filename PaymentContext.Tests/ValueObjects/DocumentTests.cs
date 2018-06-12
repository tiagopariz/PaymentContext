using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, refactor

        [TestMethod]
        public void SouldReturnErrorWhenCnpjIsInvalid()
        {
            var doc = new Document("123", 
                                   EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void SouldReturnSuccessWhenCnpjIsValid()
        {
            var doc = new Document("91639448000105", 
                                   EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void SouldReturnErrorWhenCpfIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void SouldReturnSuccessWhenCpfIsValid()
        {
            var doc = new Document("33250250724", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("21668148919")]
        [DataRow("36818266509")]
        [DataRow("11180294459")]
        [DataRow("57074118605")]
        [DataRow("39240577882")]
        public void SouldReturnSuccessWhen5CpfIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}