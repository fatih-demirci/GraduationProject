namespace NotificationService.Api.Mailing
{
    public interface IMailService
    {
        Task SendAsync(Mail mail);
    }
}
