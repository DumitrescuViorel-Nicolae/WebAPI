using Microsoft.Extensions.Options;
using Models.MailingModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailing.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpConfig;

        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        private async Task SendEmails(UserEmaiOptions userEmaiOptions)
        {
            // Configure mail to be sent
            MailMessage mail = new MailMessage()
            {
                Subject = userEmaiOptions.Subject,
                Body = userEmaiOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAdress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML,
                BodyEncoding = Encoding.Default
            };
            foreach (var email in userEmaiOptions.ToEmails)
            {
                mail.To.Add(email);
            }

            // Create client
            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredetials,
                Credentials = networkCredential,
            };

            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(_smtpConfig.EmailBodyPath, templateName));
            return body;
        }

        // Dynamic Templates functionality
        // kinda indian a bit
        private string ReplacePlaceholders(string body, List<KeyValuePair<string, string>> placeholders)
        {
            if(!string.IsNullOrEmpty(body) && placeholders != null)
            {
                foreach(var placeholdersItem in placeholders)
                {
                    if (body.Contains(placeholdersItem.Key))
                    {
                       body = body.Replace(placeholdersItem.Key, placeholdersItem.Value);
                    }
                }
            }
            return body;
        }

        public async Task SendTestEmail(UserEmaiOptions userEmaiOptions)
        {
            userEmaiOptions.Subject = "Test Email";
            userEmaiOptions.Body = GetEmailBody("EmailTemplate");
            userEmaiOptions.ToEmails = new List<string>() { "ceva@gmail.com" };
            userEmaiOptions.Placeholders.Add(new KeyValuePair<string, string>("{username}", "nick"));

            await SendEmails(userEmaiOptions);
        }
    }
}
