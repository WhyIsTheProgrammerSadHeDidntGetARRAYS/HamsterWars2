using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHamsterService> _hamsterService;
        private readonly Lazy<IMatchDataService> _matchDataService; //TODO: Ta bort DI av ILoggermanager ifrån hamsterservice/matchservice, då jag har egen felhantering
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _hamsterService = new Lazy<IHamsterService>(() => 
            new HamsterService(repositoryManager,/* logger,*/ mapper));
            
            _matchDataService = new Lazy<IMatchDataService>(() => 
            new MatchDataService(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(userManager, mapper, logger, configuration));
        }
        public IHamsterService HamsterService => _hamsterService.Value;
        public IMatchDataService MatchDataService => _matchDataService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
