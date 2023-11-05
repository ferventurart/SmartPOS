using SmartPOS.Products.Application.Abstractions.Email;

namespace SmartPOS.Products.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}