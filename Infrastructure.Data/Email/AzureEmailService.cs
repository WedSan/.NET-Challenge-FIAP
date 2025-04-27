using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Application.Interfaces;
using Azure;
using Azure.Communication.Email;

namespace Application.Services.Email;

public class AzureEmailService : IEmailService
{
    
    private EmailClient _emailClient;
    private String _sender;

    public AzureEmailService()
    {
        _sender = Environment.GetEnvironmentVariable("AZURE-DEFAULT-SENDER-EMAIL");
        string connectionString = Environment.GetEnvironmentVariable("AZURE-DOTNET-EMAIL-SERVICE-CONNECTION-STRING");
        _emailClient = new EmailClient(connectionString);
    }

    public async Task SendEmail(String targetEmail, EmailMessage message)
    {
        var emailMessage = new Azure.Communication.Email.EmailMessage(
            senderAddress: _sender,
            content: new EmailContent(message.Subject)
            {
                PlainText = message.Content,
            },
            recipients: new EmailRecipients(new List<EmailAddress> { new EmailAddress(targetEmail) }));
        
        await _emailClient.SendAsync(WaitUntil.Completed, emailMessage);
    }
    
}