using rgomezj.Freelance.Me.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Services.Abstract
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage emailMessage);
    }
}
