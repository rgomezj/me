﻿using rgomezj.Freelance.Me.Core;
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
    public class JSONReferenceRepository : JSONConfigContext, IReferenceRepository
    {
        public JSONReferenceRepository(JSONDatabaseConfig config) : base(config, "References.json")
        {
        }

        public async Task<List<Reference>> GetAll()
        {
            List<Reference> references = await this.GetEntity<List<Reference>>();
            return references;
        }
    }
}
