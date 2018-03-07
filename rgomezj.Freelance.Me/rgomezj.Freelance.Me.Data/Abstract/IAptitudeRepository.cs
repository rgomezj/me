using rgomezj.Freelance.Me.Core;
using rgomezj.Freelance.Me.Core.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Data.Abstract
{
    public interface IAptitudeRepository
    {
        Task<List<Aptitude>> GetAll();
    }
}
