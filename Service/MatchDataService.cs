using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MatchDataService : IMatchDataService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public MatchDataService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDataDto>> GetAllMatchesAsync(bool trackChanges)
        {
            var matches = await _repositoryManager.MatchData.GetMatchesAsync(trackChanges);
            
            if(matches == null)
            {
                //TODO: throw custom error here to get the right response to client
            }
            var matchesDto = _mapper.Map<IEnumerable<MatchDataDto>>(matches);

            return matchesDto;
        }

        public async Task<MatchDataDto> GetMatchAsync(int id, bool trackChanges)
        {
            var match = await _repositoryManager.MatchData.GetMatchAsync(id, trackChanges);
            
            if(match == null)
            {
                //TODO: throw custom error here to get the right response to client
                throw new MatchNotFoundException(id);
            }
            var matchDto = _mapper.Map<MatchDataDto>(match);
            
            return matchDto;
        }

        public async Task<IEnumerable<MatchDataDto>> GetSpecificMatchesAsync(int hamsterId, bool trackChanges)
        {
            var hamster = await _repositoryManager.Hamster.GetHamsterByIdAsync(hamsterId, trackChanges);

            if(hamster == null)
                throw new HamsterNotFoundException(hamsterId);

            var hamsterMatches = await _repositoryManager.MatchData.GetMatchesByConditionAsync(hamsterId, trackChanges);

            if (hamsterMatches == null)
                throw new MatchNotFoundException(hamsterId); //should obviously not be this id, and I dont even think you should provide and id for this

            var matchesToReturn = _mapper.Map<IEnumerable<MatchDataDto>>(hamsterMatches);

            return matchesToReturn;
        }
        public async Task<MatchDataDto> CreateMatch(MatchDataDto matchDataDto)
        {
            if (matchDataDto == null)
                throw new CreateMatchBadRequestException();
            
            var matchEntity = _mapper.Map<MatchData>(matchDataDto);

            _repositoryManager.MatchData.CreateMatch(matchEntity);
            await _repositoryManager.SaveAsync();

            var createdMatch = _mapper.Map<MatchDataDto>(matchEntity);
            return createdMatch;
        }

        public async Task DeleteMatchRow(int id, bool trackChanges)
        {
            var match = await _repositoryManager.MatchData.GetMatchAsync(id, trackChanges);
            
            if (match == null)
                throw new MatchNotFoundException(id);

            _repositoryManager.MatchData.RemoveMatch(match);
            await _repositoryManager.SaveAsync();
        }
    }
}
