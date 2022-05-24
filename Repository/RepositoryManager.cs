using Contracts;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IHamsterRepository> _hamsterRepository;
        private readonly Lazy<IMatchDataRepository> _matchDataRepository;
        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _hamsterRepository = new Lazy<IHamsterRepository>(() =>
            new HamsterRepository(context));
            _matchDataRepository = new Lazy<IMatchDataRepository>(() =>
            new MatchDataRepository(context));
        }
        public IHamsterRepository Hamster => _hamsterRepository.Value;
        public IMatchDataRepository MatchData => _matchDataRepository.Value;
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
