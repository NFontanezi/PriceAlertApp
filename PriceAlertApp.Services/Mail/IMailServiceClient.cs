using PriceAlertApp.Models.Mail;

namespace AlertApp.Services.Mail
{
    public interface IMailServiceClient
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
