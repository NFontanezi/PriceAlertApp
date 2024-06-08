using PriceAlertApp.Models.Mail;

namespace PriceAlertApp.Services.Mail
{
    public interface IMailServiceClient
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
