using MailKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BlazorServerBlog.Services
{
    public class Mail : IMailService, IEmailSender
    {

        public IConfiguration _config { get; }

        public Mail(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task SendEmail(MailboxAddress from, MailboxAddress to, string subject, BodyBuilder body)
        {

            var msg = new MimeMessage();

            msg.From.Add(from);
            msg.To.Add(to);
            msg.Subject = subject;
            msg.Body = body.ToMessageBody();

            using var client = new SmtpClient();

            client.Connect(_config["Email:server"], 587, false);
            client.Authenticate(_config["Email:user"], _config["Email:password"]);
            await client.SendAsync(msg);
            client.Disconnect(true);
        }


        public async Task SendEmail(string to, string subject, string body)
        {
            var bb = new BodyBuilder { HtmlBody = body };
            var toAddr = MailboxAddress.Parse(to);
            var fromAddr = new MailboxAddress(_config["Email:name"], _config["Email:address"]);

            await SendEmail(fromAddr, toAddr, subject, bb);

        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await SendEmail(email, subject, htmlMessage);
        }
    }
}