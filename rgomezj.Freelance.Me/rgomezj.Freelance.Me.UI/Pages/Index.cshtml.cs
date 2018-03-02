using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using rgomezj.Freelance.Me.Data.Abstract;

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

        public GeneralInfo GeneralInfo { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Company> Companies { get; private set; }
        public List<Reference> References { get; private set; }
        public List<Technology> Technologies { get; private set; }
        public List<Aptitude> Aptitudes { get; private set; }

        public IndexModel(IGeneralInfoRepository generalInfoRepository, ISkillRepository skillRepository, ICompanyRepository companyRepository, IReferenceRepository referenceRepository, ITechnologyRepository technologyRepository, IAptitudeRepository aptitudeRepository)
        {
            this._generalInfoRepository = generalInfoRepository;
            this._skillRepository = skillRepository;
            this._companyRepository = companyRepository;
            this._referenceRepository = referenceRepository;
            this._technologyRepository = technologyRepository;
            this._aptitudeRepository = aptitudeRepository;
        }

        public void OnGet()
        {
            GeneralInfo = _generalInfoRepository.Get();
            Skills = _skillRepository.GetAll().OrderBy(c=> c.SortOrder).ToList<Skill>();
            Companies = _companyRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Company>();
            References = _referenceRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Reference>();
            Technologies = _technologyRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Technology>();
            Aptitudes = _aptitudeRepository.GetAll().OrderBy(c => c.SortOrder).ToList<Aptitude>();
        }
    }
}
