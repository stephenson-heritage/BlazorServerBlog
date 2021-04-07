
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace BlazorServerBlog.Services
{
    public class Mail : IMailService
    {
        public IConfiguration Configuration { get; }
        public Mail(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmail(MailboxAddress from, MailboxAddress to, string subject, BodyBuilder body)
        {

            var msg = new MimeMessage();
            msg.From.Add(from);
            msg.To.Add(to);
            msg.Subject = subject;
            msg.Body = body.ToMessageBody();
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mailtrap.io", 587, false);
                client.Authenticate("ef209c6b7451b7", "12c83a67c2a77c");
                await client.SendAsync(msg);
                client.Disconnect(true);
            }

        }

        public async Task SendEmail(string to, string subject, string body)
        {
            var bb = new BodyBuilder();
            bb.HtmlBody = body;
            await SendEmail(
                new MailboxAddress(Configuration["Email:Name"], Configuration["Email:Address"]),
                MailboxAddress.Parse(to), subject, bb
            );
        }
    }
}