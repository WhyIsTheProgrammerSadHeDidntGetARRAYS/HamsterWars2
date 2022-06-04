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
        Task<Hamster> GetRandomHamsterAsync(bool trackChanges);
        Task VoteHamsterAsync(IEnumerable<Hamster> hamsters, bool trackChanges); 
        void DeleteHamster(Hamster hamster); 
        void CreateHamster(Hamster hamster);
        void UpdateHamster(Hamster hamster);
    }
}
