using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Services.Abstract;

namespace rgomezj.Freelance.Me.UI
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IGeneralInfoRepository _generalInfoRepository;

        public EmailController(IEmailService emailService, IGeneralInfoRepository generalInfoRepository)
        {
            this._emailService = emailService;
            this._generalInfoRepository = generalInfoRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task Post(EmailMessage emailMessage)
        {
            GeneralInfo generalInfo = await _generalInfoRepository.Get();
            emailMessage.To = generalInfo.EmailAddress;
            emailMessage.ToName = generalInfo.Name;
            _emailService.SendEmail(emailMessage);
        }
    }
}
