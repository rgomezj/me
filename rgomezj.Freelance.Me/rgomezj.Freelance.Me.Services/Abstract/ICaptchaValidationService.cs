using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Services.Abstract
{
    public interface ICaptchaValidationService
    {
        CaptchaSettings GetSettings();

        bool IsValidCaptcha(string secret, string response);
    }
}
