using ProiectDeAnMRSTW.Application.Abstractions.Email;

namespace ProiectDeAnMRSTW.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(string name, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
