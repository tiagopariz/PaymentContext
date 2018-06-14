using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Commands;
using PaymentContext.Tests.Mocks;
using PaymentContext.Domain.Queries;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students = null;

        public StudentQueriesTests()
        {
            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()),
                                          new Document("1111111111" + 1, EDocumentType.CPF),
                                          new Email(i.ToString() + "@balta.io")));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, studn);
        }   

        [TestMethod]
        public void ShouldReturnNullWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreNotEqual(null, studn);
        }        
    }
}