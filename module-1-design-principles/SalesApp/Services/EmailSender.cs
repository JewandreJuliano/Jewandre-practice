namespace SalesApp.Services;

/// <summary>
/// Fake email sender: writes to the terminal instead of sending real email.
/// </summary>
public class EmailSender
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"[EmailSender] To: {to} | Subject: {subject} | {body}");
    }
}
