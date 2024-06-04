
using AlertApp.Model;
using MailKit.Security;
using MimeKit;
using PriceAlertApp.Models.Mail;

namespace AlertApp.Services.Mail
{
    public class MailServiceClient : IMailServiceClient
    {
        private readonly MailSettings _emailSettings;
 

        public MailServiceClient()
        {
            _emailSettings = new MailSettings();

        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage
                {
                    Subject = mailRequest.Subject,
                    Sender = MailboxAddress.Parse(_emailSettings.Mail)
                };
                mailRequest.ToEmails.ForEach(recipient => email.To.Add(MailboxAddress.Parse(recipient)));

                var builder = new BodyBuilder { HtmlBody = mailRequest.Body };
                email.Body = builder.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                await Task.FromResult(smtp.Send(email));
                smtp.Disconnect(true);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error during send mail. Details: {ex.Message}. {ex}");
            }
        }



    }
}
