using AutoMapper;
using Contracts;
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
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _hamsterService = new Lazy<IHamsterService>(() => 
            new HamsterService(repositoryManager,/* logger,*/ mapper));
            
            _matchDataService = new Lazy<IMatchDataService>(() => 
            new MatchDataService(repositoryManager, logger, mapper));
        }
        public IHamsterService HamsterService => _hamsterService.Value;
        public IMatchDataService MatchDataService => _matchDataService.Value;

    }
}
