using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using rgomezj.Freelance.Me.Core.Settings;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Services.Abstract;

namespace rgomezj.Freelance.Me.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGeneralInfoRepository _generalInfoRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IAptitudeRepository _aptitudeRepository;
        private readonly IEmailService _emailService;
        private readonly ICaptchaValidationService _captchaValidationService;

        public GeneralInfo GeneralInfo { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Company> Companies { get; private set; }
        public List<Reference> References { get; private set; }
        public List<Technology> Technologies { get; private set; }
        public List<Aptitude> Aptitudes { get; private set; }

        public IndexModel(IGeneralInfoRepository generalInfoRepository, ISkillRepository skillRepository, ICompanyRepository companyRepository, IReferenceRepository referenceRepository, ITechnologyRepository technologyRepository, IAptitudeRepository aptitudeRepository, IEmailService emailService, ICaptchaValidationService captchaValidationService)
        {
            this._generalInfoRepository = generalInfoRepository;
            this._skillRepository = skillRepository;
            this._companyRepository = companyRepository;
            this._referenceRepository = referenceRepository;
            this._technologyRepository = technologyRepository;
            this._aptitudeRepository = aptitudeRepository;
            this._emailService = emailService;
            this._captchaValidationService = captchaValidationService;
        }

        public void OnGet()
        {
            GeneralInfo = _generalInfoRepository.Get();
            Skills = _skillRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Skill>();
            Companies = _companyRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Company>();
            References = _referenceRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Reference>();
            Technologies = _technologyRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Technology>();
            Aptitudes = _aptitudeRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Aptitude>();
        }

        [ValidateAntiForgeryToken]
        public ActionResult OnPost(EmailMessage emailMessage)
        {
            string errorMessage = string.Empty;
            bool success = true;
            GeneralInfo generalInfo = _generalInfoRepository.Get();
            CaptchaSettings captchaSettings = _captchaValidationService.GetSettings();
            string captchaResponse = Request.Form[captchaSettings.CaptchaResponseKey];
            string name = System.Net.WebUtility.HtmlEncode(emailMessage.FromName);

            if (_captchaValidationService.IsValidCaptcha(captchaSettings.SecretKey, captchaResponse))
            {
                emailMessage.To = generalInfo.EmailAddress;
                emailMessage.ToName = generalInfo.Name;
                emailMessage.Message = emailMessage.Message + Environment.NewLine + emailMessage.FromName + Environment.NewLine + emailMessage.From;
                try
                {
                    _emailService.SendEmail(emailMessage);
                }
                catch
                {
                    errorMessage = $"Sorry {name}, it seems that my mail server is not responding. Please try again later!";
                    success = false;
                }
            }
            else
            {
                errorMessage = "Captcha validation didn't pass, please try again";
                success = false;
            }
            return new JsonResult( new { success,  errorMessage });
        }
    }
}
