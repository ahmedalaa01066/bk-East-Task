using EasyTask.Features.Common.Emails.DTOs;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
namespace EasyTask.Helpers
{
    public static class EmailHelper
    {
        public static async Task<EmailDTO> SendEmailAsync(List<string> toEmails, string subject, string body)
{
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("EasyTask", "EasyTask99@gmail.com"));

            foreach (var email in toEmails)
            {
                message.To.Add(MailboxAddress.Parse(email));
            }

            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Connect to Gmail SMTP
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    // Use an App Password if 2FA is enabled
                    await client.AuthenticateAsync("EasyTask99@gmail.com", "xasi xsra tdcl tnkg");

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    throw new Exception("Email sending failed: " + ex.Message, ex);
                }
            }

            return new EmailDTO
            {
                Subject = subject,
                Body = body,
                EmailAdresses = toEmails
            };
        }

    }
}
