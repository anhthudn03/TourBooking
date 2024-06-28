using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using BusinessLogic.Dtos.SendMailModel;

namespace BusinessLogic.Business.SendmailService
{
    public class EmailService :IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendMail(EmailDto request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.EmailToName));
                email.Subject = request.EmailSubject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.EmailBody };

                using var smtp = new SmtpClient();
                smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                return false;
            }
           
        }
    }
}
