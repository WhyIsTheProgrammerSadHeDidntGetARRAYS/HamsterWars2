using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMatchDataService
    {
        Task<IEnumerable<MatchDataDto>> GetAllMatchesAsync(bool trackChanges);
        Task<MatchDataDto> GetMatchAsync(int id, bool trackChanges);
        Task<IEnumerable<MatchDataDto>> GetSpecificMatchesAsync(int hamsterId, bool trackChanges);
        Task<MatchDataDto> CreateMatch(MatchDataDto matchDataDto);
        Task DeleteMatchRow(int id, bool trackChanges);
    }
}
