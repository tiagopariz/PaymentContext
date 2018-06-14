using PaymentContext.Domain.Services;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to,
                         string email,
                         string subject,
                         string body)
        {
             return;           
        }
    }
}