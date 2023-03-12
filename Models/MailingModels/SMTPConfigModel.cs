using System;
using System.Collections.Generic;
using System.Text;

namespace Models.MailingModels
{
    public class SMTPConfigModel
    {
        public string SenderAdress { get; set; }
        public string SenderDisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredetials { get; set; }
        public bool IsBodyHTML { get; set; }
        public string EmailBodyPath { get; set; }
    }
}
