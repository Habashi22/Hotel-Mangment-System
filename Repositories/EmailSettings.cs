
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
//using System.Net.Mail;
using MailKit.Net.Smtp;

namespace MVCBookingFinal_YARAB_.Helpers
{
    public class EmailSettings : IEmailSettings
    {
        private readonly MailSettings _options;

        public EmailSettings(IOptions<MailSettings> options)
        {
            _options = options.Value;
        }

        public void SendEmail(Email2 email)
        {
            //34n a3rf ast5dm el7gat el fel appsettings
            //inject subject mn 7aga bt implement ioptions


            var mail = new MimeMessage
            {
                Subject= email.Subject
            };
            mail.To.Add(MailboxAddress.Parse(email.To));
            mail.From.Add(new MailboxAddress(_options.DisplayName, _options.Email));

            var builder = new BodyBuilder();
            builder.TextBody = email.Body;
            mail.Body = builder.ToMessageBody();


            using var smtp = new SmtpClient();
            smtp.Connect(_options.Host, _options.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.Email, _options.Password);

            smtp.Send(mail);
            smtp.Disconnect(true);


        }
    }
}
