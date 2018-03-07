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
    public class JSONSkillRepository : JSONConfigContext, ISkillRepository
    {
        public JSONSkillRepository(JSONDatabaseConfig config) : base(config, "Skills.json")
        {
        }

        public async Task<List<Skill>> GetAll()
        {
            List<Skill> skills = await this.GetEntity<List<Skill>>();
            return skills;
        }
    }
}
