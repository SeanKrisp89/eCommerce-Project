using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N7Emporium.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailSender(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@N7Emporium.com", "N7 Administration"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            return _sendGridClient.SendEmailAsync(msg);
        }

    }
}
