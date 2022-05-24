using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<MatchData> GetMatchAsync(int id, bool trackChanges) =>
            await FindByCondition(m => m.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }
}
