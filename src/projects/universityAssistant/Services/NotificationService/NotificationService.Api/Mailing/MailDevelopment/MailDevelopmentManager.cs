namespace NotificationService.Api.Mailing.MailDevelopment
{
    public class MailDevelopmentManager : IMailService
    {
        public Task SendAsync(Mail mail)
        {
            Console.WriteLine($"Email : {mail.ToEmail} ToFullName : {mail.ToFullName} Title : {mail.Subject} Body : {mail.HtmlBody}");
            return Task.CompletedTask;
        }
    }
}
