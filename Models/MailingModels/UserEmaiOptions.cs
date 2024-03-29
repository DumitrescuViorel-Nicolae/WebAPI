﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.MailingModels
{
    public class UserEmaiOptions
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string, string>> Placeholders { get; set; }
    }
}
