using Application.Services.Email;

namespace Application.Interfaces;

public interface IEmailService
{
     Task SendEmail(String targetEmail, EmailMessage message);
}