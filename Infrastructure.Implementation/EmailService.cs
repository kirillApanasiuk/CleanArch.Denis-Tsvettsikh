using Infrastructure.Interfaces.Integrations;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string address, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
