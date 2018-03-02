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
    public class JSONTechnologyRepository : JSONConfigContext, ITechnologyRepository
    {
        public JSONTechnologyRepository(JSONDatabaseConfig config) : base(config, "Technologies.json")
        {
        }

        public List<Technology> GetAll()
        {
            List<Technology> technologies = this.GetEntity<List<Technology>>();
            return technologies;
        }
    }
}
