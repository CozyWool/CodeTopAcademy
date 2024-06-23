using System.Net;
using System.Net.Mail;
using MimeKit;


// SendMailWithSmtpClient();
await SendWithMailkit();
return;

static void SendMailWithSmtpClient()
{
    const string from = "********";
    const string recipient = "*******";
    const string password = "*******";
    var client = new SmtpClient("smtp.gmail.com", 25)
    {
        Credentials = new NetworkCredential(from, password),
        EnableSsl = true
    };

    client.Send(from, recipient, "Some spaaaaaaaam", "Hello world!!!!!");
}

async Task SendWithMailkit()
{
    const string from = "********";
    const string recipient = "*******";
    const string password = "********";

    using var emailMessage = new MimeMessage();
    emailMessage.From.Add(new MailboxAddress("Я", from));
    emailMessage.To.Add(new MailboxAddress("Другой я", recipient));
    emailMessage.Subject = "Тема MailKit";
    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
    {
        Text = "qwertyasdfgh"
    };

    using var smptClient = new MailKit.Net.Smtp.SmtpClient();
    await smptClient.ConnectAsync("smtp.gmail.com", 25);
    await smptClient.AuthenticateAsync(new NetworkCredential(from, password));
    await smptClient.SendAsync(emailMessage);
    await smptClient.DisconnectAsync(true);
}