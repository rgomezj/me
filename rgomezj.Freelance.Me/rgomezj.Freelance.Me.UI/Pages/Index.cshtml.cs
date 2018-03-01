using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Data.Abstract;

namespace rgomezj.Freelance.Me.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGeneralInfoRepository _generalInfoRepository;
        public GeneralInfo GeneralInfo;

        public IndexModel(IGeneralInfoRepository generalInfoRepository)
        {
            this._generalInfoRepository = generalInfoRepository;
        }

        public void OnGet()
        {
            GeneralInfo = _generalInfoRepository.Get();
        }
    }
}
