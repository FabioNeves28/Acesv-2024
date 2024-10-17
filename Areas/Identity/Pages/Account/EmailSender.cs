//using Acesvv.Areas.Identity.Data;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Options;
//using System.Net;
//using System.Net.Mail;

//namespace Acesvv.Areas.Identity.Pages.Account
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly EmailSenderOptions _emailOptions;

//        public EmailSender(IOptions<EmailSenderOptions> emailOptions)
//        {
//            _emailOptions = emailOptions.Value;
//        }

//        public Task SendEmailAsync(string email, string subject, string message)
//        {
//            var smtpClient = new SmtpClient(_emailOptions.SmtpServer)
//            {
//                Port = _emailOptions.SmtpPort,
//                Credentials = new NetworkCredential(_emailOptions.UserName, _emailOptions.Password),
//                EnableSsl = true,
//            };

//            return smtpClient.SendMailAsync(new MailMessage(_emailOptions.From, email, subject, message)
//            {
//                IsBodyHtml = true
//            });
//        }
//    }


//}

