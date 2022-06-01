using Shared.DataTransferObjects;

namespace HamsterWars2.Client.Services
{
    public interface IHttpRequestService
    {
        Task<IEnumerable<HamsterDto>> GetHamstersAsync();
        Task<HamsterDto> GetHamsterByIdAsync(int id);
        Task<HamsterDto> GetRandomHamsterAsync();
        Task<bool> CreateHamster(CreateHamsterDto newHamster);
        Task<bool> VoteForHamster(MatchCompletedDto hamster);
        Task<bool> RegisterMatchData(MatchDataDto matchDataDto);
        Task<IEnumerable<HamsterDto>> GetTopFiveHamsters();
        Task<IEnumerable<HamsterDto>> GetBottomFiveHamsters();
        Task<IEnumerable<HamsterDto>> GetSpecificHamsterMatchData(int hamsterId);
    }
}
