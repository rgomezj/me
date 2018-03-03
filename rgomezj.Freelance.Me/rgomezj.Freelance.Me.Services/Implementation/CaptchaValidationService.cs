using Newtonsoft.Json;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Settings;
using rgomezj.Freelance.Me.Services.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Services.Implementation
{
    public class CaptchaValidationService : ICaptchaValidationService
    {
        CaptchaSettings _captchaSettings;

        public CaptchaValidationService(CaptchaSettings captchaSettings)
        {
            _captchaSettings = captchaSettings;
        }

        public CaptchaSettings GetSettings()
        {
            return _captchaSettings;
        }

        public bool IsValidCaptcha(string secret, string response)
        {
            bool validCaptcha = false;
            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("secret", secret),
                    new KeyValuePair<string,string>("response", response)
                });

            using (HttpResponseMessage captchaHttpResponse = client.PostAsync(this._captchaSettings.URLVerification, content).Result)
            {
                string responseString = captchaHttpResponse.Content.ReadAsStringAsync().Result;
                CaptchaResponse captchaReponse = JsonConvert.DeserializeObject<CaptchaResponse>(responseString);
                validCaptcha = captchaReponse.success;
            }
            return validCaptcha;
        }
    }
}
