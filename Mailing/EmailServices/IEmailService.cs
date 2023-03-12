using Models.MailingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mailing.EmailServices
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmaiOptions userEmaiOptions);
    }
}
