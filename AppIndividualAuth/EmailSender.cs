
namespace WebApp_IndividualAuth
{
    public class EmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        private readonly ISendGridHelper sendGridHelper;

        public EmailSender(ISendGridHelper sendGridHelper)
        {
            this.sendGridHelper = sendGridHelper;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await sendGridHelper.Execute(email, subject, htmlMessage);
        }
    }
}
