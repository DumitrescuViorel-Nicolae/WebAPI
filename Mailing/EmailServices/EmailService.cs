using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Models.MailingModels;
using System;
using System.Collections.Generic;
using System.IO;
//using System.Net;
//using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using NgrokApi;

namespace Mailing.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpConfig;
        private readonly string ApiKey ="2dccfbbc39f927e444d716568a9c3172621be8e1";
        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        private async Task SendEmails()
        {
            // Configure mail to be sent
            //MailMessage mail = new MailMessage()
            //{
            //    Subject = userEmaiOptions.Subject,
            //    Body = userEmaiOptions.Body,
            //    From = new MailAddress(_smtpConfig.SenderAdress, _smtpConfig.SenderDisplayName),
            //    IsBodyHtml = _smtpConfig.IsBodyHTML,
            //    BodyEncoding = Encoding.Default,
            //};

            //foreach (var email in userEmaiOptions.ToEmails)
            //{
            //    mail.To.Add(email);
            //}

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "arrow6660675dumitrescu@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "dterminator2020@gmail.com"));
            message.Subject = "Test Email";
            message.Body = new TextPart("plain")
            {
                Text = "This is a test email"
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_smtpConfig.Host, _smtpConfig.Port);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("smtp-317@smtp-388909.iam.gserviceaccount.com", ApiKey);
                client.Send(message);
                client.Disconnect(true);
            }


            // Create client
            //NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);
            //SmtpClient smtpClient = new SmtpClient()
            //{
            //    Host = _smtpConfig.Host,
            //    Port = _smtpConfig.Port,
            //    EnableSsl = _smtpConfig.EnableSSL,
            //    UseDefaultCredentials = _smtpConfig.UseDefaultCredetials,
            //    Credentials = networkCredential,
            //};

            //await smtpClient.SendMailAsync(mail);
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
            if(!string.IsNullOrEmpty(body) && placeholders!= null)
            {
                foreach(var placeholdersItem in placeholders)
                {
                    if (body.Contains(placeholdersItem.Key) && placeholdersItem.Key != null)
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
            userEmaiOptions.ToEmails = new List<string>() { "dterminator2020@gmail.com" };
            userEmaiOptions.Placeholders.Add(new KeyValuePair<string, string>("{username}", "nick"));

            await SendEmails();
        }
    }
}
