using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public class JSONGeneralInfoRepository : JSONConfigContext, IGeneralInfoRepository 
    {
        public JSONGeneralInfoRepository(JSONDatabaseConfig config) : base(config, "GeneralInfo.json")
        {
        }

        public GeneralInfo Get()
        {
            GeneralInfo generalInfo = this.GetEntity<GeneralInfo>();
            return generalInfo;
        }
    }
}
