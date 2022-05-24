using Entities.Models;

namespace Contracts
{
    public interface IHamsterRepository
    {
        Task<IEnumerable<Hamster>> GetAllHamstersAsync(bool trackChanges);
        Task<Hamster> GetHamsterByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Hamster>> GetTopFiveHamstersAsync(bool trackChanges);
        Task<IEnumerable<Hamster>> GetBottomFiveHamstersAsync(bool trackChanges);
        Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync(bool trackChanges);
        Task VoteHamsterAsync(IEnumerable<Hamster> hamsters, bool trackChanges); //should be true here? should be void? same as comment below as well
        void DeleteHamster(Hamster hamster); //should be true here? maybe remove trackChanges from non read-only queries 
        void CreateHamster(Hamster hamster);
        void UpdateHamster(Hamster hamster);
    }
}
