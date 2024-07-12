using System;
using MailKit.Net.Smtp;
using MimeKit;

public class EmailHelper
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string smtpUser;
    private readonly string smtpPass;

    public EmailHelper(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
    {
        this.smtpServer = smtpServer;
        this.smtpPort = smtpPort;
        this.smtpUser = smtpUser;
        this.smtpPass = smtpPass;
    }

    public void SendOtpEmail(string recipientEmail, string otp)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("FindMyBooks", smtpUser));
        message.To.Add(new MailboxAddress("ahiresagar06130@gmail.com", recipientEmail));
        message.Subject = "Your OTP Code";

        message.Body = new TextPart("plain")
        {
            Text = $"Your OTP code is: {otp}"
        };

        using (var client = new SmtpClient())
        {
            // For demo purposes, accept all SSL certificates (in case the server supports STARTTLS)
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect(smtpServer, smtpPort, false);
            client.Authenticate(smtpUser, smtpPass);

            client.Send(message);
            client.Disconnect(true);
        }
    }

    public static string GenerateOtp()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString(); // Generates a 6-digit OTP
    }
}
