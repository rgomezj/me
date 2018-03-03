using rgomezj.Freelance.Me.Core.Settings;
using rgomezj.Freelance.Me.Services.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Services.Implementation
{
    public class SendGridEmailService : IEmailService
    {
        private EmailSettings _emailSettings;
        
        public SendGridEmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendEmail()
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@example.com", "DX Team"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            msg.AddTo(new EmailAddress("rogergomez780@gmail.com", "Test User"));
            client.SendEmailAsync(msg).Wait();
        }
    }
}
