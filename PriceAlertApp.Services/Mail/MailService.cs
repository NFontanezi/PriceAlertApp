﻿using PriceAlertApp.Models;
using PriceAlertApp.Models.Mail;

namespace PriceAlertApp.Services.Mail
{
    public class MailService : IMailService
    {
        private IMailServiceClient _mailServiceClient;
        private MailCredential _credential;

        public MailService(IMailServiceClient mailServiceClient)
        {
            _mailServiceClient = mailServiceClient; 
            Initialize(MailCredentialFactory.BuildCredential());
        }

        private void Initialize(MailCredential credential)
        {
            _credential = credential;
        }

        public async Task SendAlertEmail(StockData stockData, string actionSale, double input)
        {
            var mailRequest = new MailRequest();
            mailRequest.Credential = _credential;
            await BuildEmail(stockData, actionSale, input, mailRequest);

            Console.WriteLine($"Sending email alert: {stockData.Symbol}");
            await _mailServiceClient.SendEmailAsync(mailRequest);

        }

        private async Task BuildEmail(StockData stockData, string actionSale, double input, MailRequest mail)
        {
            var subject = "[ALERT STOCK PRICE]";

            var messageText = string.Empty;

            messageText += "<p>Hi,</p>";
            messageText += $"<p>The limit price for {stockData.Symbol} was achieved!</p>";
            messageText += $"<p>Stock price target price: {input}. Current Price: {stockData.DailyCloses.FirstOrDefault().Close} Action: {actionSale} </p>";
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
