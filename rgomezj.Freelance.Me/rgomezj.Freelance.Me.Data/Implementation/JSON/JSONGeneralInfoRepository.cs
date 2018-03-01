using Microsoft.Extensions.Options;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Data.Abstract;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public class JSONGeneralInfoRepository : IGeneralInfoRepository
    {
        JSONDatabaseConfig _config;
        
        public JSONGeneralInfoRepository(JSONDatabaseConfig config)
        {
            this._config = config;
        }

        public GeneralInfo Get()
        {
            Console.WriteLine(_config.Files.GeneralInfo);
            return new GeneralInfo() { ClientsFreelanceCount = 2, DynamicsCRMProjectsDelivered = 10, YearsTechnicalLead = 3, YearsWorkingSoftware = 10 };
        }
    }
}
