using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public class JSONCompanyRepository : JSONConfigContext, ICompanyRepository
    {
        public JSONCompanyRepository(JSONDatabaseConfig config) : base(config, "Companies.json")
        {
        }

        public List<Company> GetAll()
        {
            List<Company> companies = this.GetEntity<List<Company>>();
            return companies;
        }
    }
}
