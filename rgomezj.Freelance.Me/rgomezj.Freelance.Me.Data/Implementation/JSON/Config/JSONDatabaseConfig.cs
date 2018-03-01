using Microsoft.Extensions.Options;
using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON.Config
{
    public class JSONDatabaseConfig
    {
        public string BasePath { get; set; }

        public JSONDBFiles Files { get; set; }
    }
}
