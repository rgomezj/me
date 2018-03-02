using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace rgomezj.Freelance.Me.Data.Abstract
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
