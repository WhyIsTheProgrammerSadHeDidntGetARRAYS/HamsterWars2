using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMatchDataRepository
    {
        Task<IEnumerable<MatchData>> GetMatchesAsync(bool trackChanges);
        Task<MatchData> GetMatchAsync(int id, bool trackChanges);
    }
}
