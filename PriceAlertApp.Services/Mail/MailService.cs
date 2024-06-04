


using PriceAlertApp.Models;
using PriceAlertApp.Models.Mail;

namespace AlertApp.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IMailServiceClient _mailServiceClient;
        public MailService()
        {
            _mailServiceClient = new MailServiceClient();
        }

        public async Task SendAlertEmail(StockData stockData, string actionSale, double input)
        {
            var mailRequest = new MailRequest();
            await BuildEmail(stockData, actionSale, input, mailRequest);


           await _mailServiceClient.SendEmailAsync(mailRequest);

        }

        private async Task BuildEmail(StockData stockData, string actionSale, double input, MailRequest mail)
        {
            var subject = "[ALERT STOCK PRICE]";

            var messageText = string.Empty;

            messageText += "<p>Hi,</p>";
            messageText += $"<p>The limit price for {stockData.Symbol} was achieved!</p>";
            messageText += $"<p>Stock price is Target price: {input}  {stockData.Symbol} was achieved!</p>";
            messageText += "<br />";

            mail.Subject = subject;
            mail.Body = messageText;
            mail.ToEmails = GetRecipients();
        }

        private static List<string> GetRecipients()
        {
            return new List<string>
            {
                "natalia.fontanezi@gmail.com"
            };
        }

    }
}
