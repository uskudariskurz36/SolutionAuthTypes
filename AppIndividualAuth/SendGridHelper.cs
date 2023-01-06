using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Options;

namespace WebApp_IndividualAuth
{
    public interface ISendGridHelper
    {
        Task Execute(string email, string subject, string htmlMessage);
    }

    public class SendGridHelper : ISendGridHelper
    {
        private readonly IConfiguration configuration;

        public SendGridHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Execute(string email, string subject, string htmlMessage)
        {
            var apiKey = configuration.GetValue<string>("AppSettings:SendGridKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("uskudar.iskur.z36@gmail.com", "Test Account");
            var to = new EmailAddress(email);
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);

            //_logger.LogInformation(response.IsSuccessStatusCode
            //                   ? $"Email to {toEmail} queued successfully!"
            //                   : $"Failure Email to {toEmail}");
        }
    }
}
