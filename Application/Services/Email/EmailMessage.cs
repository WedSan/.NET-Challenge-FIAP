namespace Application.Services.Email;

public record EmailMessage
{
    public string Subject { get; init; }
    public string Content { get; init; }

    public EmailMessage(string subject, string content)
    {
        Subject = subject;
        Content = content;
    }
}