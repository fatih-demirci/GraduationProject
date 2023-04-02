using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Security.Authentication;
using System.Text;

namespace NotificationService.Api.Mailing.MailKit
{
    public class MailKitManager : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailKitManager(IConfiguration configuration)
        {
            _mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>()!;
        }

        public async Task SendAsync(Mail mail)
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));

            email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));

            email.Subject = mail.Subject;

            BodyBuilder bodyBuilder = new()
            {
                HtmlBody = mail.HtmlBody
            };

            if (mail.Attachments != null)
                foreach (MimeEntity? attachment in mail.Attachments)
                    bodyBuilder.Attachments.Add(attachment);

            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtp = new();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Timeout = _mailSettings.Timeout;
            await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, SecureSocketOptions.Auto);
            await smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
