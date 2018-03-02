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
    public class JSONAptitudeRepository : JSONConfigContext, IAptitudeRepository
    {
        public JSONAptitudeRepository(JSONDatabaseConfig config) : base(config, "Aptitudes.json")
        {
        }

        public List<Aptitude> GetAll()
        {
            List<Aptitude> aptitudes = this.GetEntity<List<Aptitude>>();
            return aptitudes;
        }
    }
}
