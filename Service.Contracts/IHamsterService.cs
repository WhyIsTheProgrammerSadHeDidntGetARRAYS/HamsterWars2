using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHamsterService
    {
        Task<IEnumerable<HamsterDto>> GetAllHamstersAsync(bool trackChanges);
        Task<HamsterDto> GetHamsterByIdAsync(int id, bool trackChanges);
        Task<HamsterDto> GetRandomHamster(bool trackChanges);
        Task<IEnumerable<HamsterDto>> GetSpecificHamsterWins(int id, bool trackChanges);
        Task<IEnumerable<MatchResultsDto>> GetAllHamsterMatches(bool trackChanges);
        Task<IEnumerable<HamsterDto>> GetTopFiveHamstersAsync(bool trackChanges);
        Task<IEnumerable<HamsterDto>> GetBottomFiveHamstersAsync(bool trackChanges);
        Task<HamsterDto> CreateHamsterAsync(CreateHamsterDto newHamsterDto);
        Task DeleteHamsterAsync(int id, bool trackChanges);
        Task UpdateHamsterAsync(int id, UpdateHamsterDto updateHamsterDto, bool trackChanges);
    }
}
