using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public class JSONCompanyRepository : JSONConfigContext, ICompanyRepository
    {
        public JSONCompanyRepository(JSONDatabaseConfig config) : base(config, "Companies.json")
        {
        }

        public async Task<List<Company>> GetAll()
        {
            var companies = await this.GetEntity<List<Company>>();
            return companies;
        }
    }
}
