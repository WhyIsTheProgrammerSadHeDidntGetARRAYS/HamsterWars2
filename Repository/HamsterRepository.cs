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
    public class HamsterRepository : RepositoryBase<Hamster>, IHamsterRepository
    {
        public HamsterRepository(AppDbContext context) : base(context)
        { }
        public async Task<IEnumerable<Hamster>> GetAllHamstersAsync(bool trackChanges) => 
           await FindAll(trackChanges)
            .OrderBy(h => h.Id)
            .ToListAsync();
        
        public async Task<Hamster> GetHamsterByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();

        public void DeleteHamster(Hamster hamster) =>
            Delete(hamster);

        //TODO: Fixa så att ifall det inte finns registrerad matchdata för hamstrarna, returna inga hamsterobjekt
        // Just nu "fungerar" det bara ifall det finns tillräckligt med matchdata, för att annars lämnar entity framework bara tillbaka det 5 första objekten
        // även fast ingen matchdata finns
        public async Task<IEnumerable<Hamster>> GetTopFiveHamstersAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .OrderBy(h => h.Wins)
            .Take(5)
            .ToListAsync();

        public async Task<IEnumerable<Hamster>> GetBottomFiveHamstersAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderByDescending(h => h.Defeats)
            .Take(5)
            .ToListAsync();

        public void CreateHamster(Hamster hamster) =>
            Create(hamster);

        public void UpdateHamster(Hamster hamster) => 
            Update(hamster);
            
        public Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task VoteHamsterAsync(IEnumerable<Hamster> hamsters, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
