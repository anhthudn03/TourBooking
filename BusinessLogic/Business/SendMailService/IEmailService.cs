using BusinessLogic.Dtos.SendMailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Business.SendmailService
{
    public interface IEmailService
    {
        Task<bool> SendMail(EmailDto email);
    }
}
