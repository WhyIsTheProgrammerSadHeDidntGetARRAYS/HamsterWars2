using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;


namespace Repository
{
    public class MatchDataRepository : RepositoryBase<MatchData>, IMatchDataRepository
    {
        public MatchDataRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<MatchData>> GetMatchesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(m => m.Id)
            .ToListAsync();

        public async Task<IEnumerable<MatchData>> GetMatchesByConditionAsync(int hamsterId, bool trackChanges) =>
           await FindByCondition(m => m.WinnerId == hamsterId, trackChanges)
           .OrderBy(m => m.Id)
           .Distinct()
           .ToListAsync();

        public async Task<MatchData> GetMatchAsync(int id, bool trackChanges) =>
            await FindByCondition(m => m.Id == id, trackChanges)
            .FirstOrDefaultAsync();

        public void CreateMatch(MatchData matchData) => Create(matchData);

        public void RemoveMatch(MatchData matchData) => Delete(matchData);


    }
}
