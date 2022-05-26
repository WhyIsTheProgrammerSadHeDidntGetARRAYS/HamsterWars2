using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IHamsterService HamsterService { get; }
        IMatchDataService MatchDataService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
