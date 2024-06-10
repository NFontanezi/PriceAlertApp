using MailKit.Security;
using MimeKit;
using PriceAlertApp.Models.Mail;

namespace PriceAlertApp.Services.Mail
{
    public class MailServiceClient : IMailServiceClient
    {

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage
                {
                    Subject = mailRequest.Subject,
                    Sender = MailboxAddress.Parse(mailRequest.Credential.Mail)
                };
                mailRequest.ToEmails.ForEach(recipient => email.To.Add(MailboxAddress.Parse(recipient)));

                var builder = new BodyBuilder { HtmlBody = mailRequest.Body };
                email.Body = builder.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(mailRequest.Credential.Host, mailRequest.Credential.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailRequest.Credential.Mail, mailRequest.Credential.Password);
                await Task.FromResult(smtp.Send(email));
                smtp.Disconnect(true);

                Console.WriteLine($"Alert email sent");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error during send mail\n {ex.Message}");
            }
        }



    }
}
