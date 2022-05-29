using Shared.DataTransferObjects;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace HamsterWars2.Client.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _httpClient;
        
        public HttpRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //TODO: Dessa två metoder är i princip exakt samma, så detta borde kunna lösas på ett generiskt sätt för get-metoder
        public async Task<IEnumerable<HamsterDto>> GetHamstersAsync()
        {
            var response = await _httpClient.GetAsync("api/hamsters");

            if(!response.IsSuccessStatusCode)
                throw new ApplicationException($"Failed to fetch hamsters from server. Reason: {response.ReasonPhrase}");

            var content = await response.Content.ReadAsStringAsync();

            var hamsters = JsonSerializer.Deserialize<IEnumerable<HamsterDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return hamsters;
        }
        public async Task<HamsterDto> GetHamsterByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/hamsters/{id}");

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Failed to fetch hamster from server. Reason: {response.ReasonPhrase}");

            var content = await response.Content.ReadAsStringAsync();

            var hamster = JsonSerializer.Deserialize<HamsterDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return hamster;
        }
        public async Task<HamsterDto> GetRandomHamsterAsync()
        {
            var response = await _httpClient.GetAsync("api/hamsters/random"); //TODO: should probably not hardcode uri's
            
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"The response from the server failed. Reason: {response.ReasonPhrase}");
            
            var content = await response.Content.ReadAsStringAsync();
            
            var hamster = JsonSerializer.Deserialize<HamsterDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 
            
            return hamster;
        }
        public async Task<IEnumerable<HamsterDto>> GetTopFiveHamsters()
        {
            var response = await _httpClient.GetAsync("api/hamsters/bottomfive");

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Something went wrong");

            var content = await response.Content.ReadAsStringAsync();

            var bottomFiveHamsters = JsonSerializer.Deserialize<IEnumerable<HamsterDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return bottomFiveHamsters;
        }
        public async Task<IEnumerable<HamsterDto>> GetBottomFiveHamsters()
        {
            var response = await _httpClient.GetAsync("api/hamsters/topfive");

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Something went wrong");

            var content = await response.Content.ReadAsStringAsync();

            var topFiveHamsters = JsonSerializer.Deserialize<IEnumerable<HamsterDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return topFiveHamsters;
        }

        public async Task<bool> VoteForHamster(MatchCompletedDto hamster)
        {
            if (hamster == null)
                throw new ArgumentNullException(nameof(hamster));

            if (hamster.MatchWon)
            {
                hamster.HamsterCompetitor.Wins++;
            }
            else
            {
                hamster.HamsterCompetitor.Defeats++;
            }
            
            hamster.HamsterCompetitor.TotalGames++;

            var response = await _httpClient.PutAsJsonAsync($"api/hamsters/{hamster.HamsterCompetitor.Id}", hamster.HamsterCompetitor);

            return response.StatusCode == HttpStatusCode.NoContent; //no content eftersom att det är vad api'n returnerar
        }

        public async Task<bool> RegisterMatchData(MatchDataDto matchData)
        {
            if(matchData == null)
                throw new ArgumentNullException(nameof(matchData));
            
            var response = await _httpClient.PostAsJsonAsync("api/match", matchData);

            return response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<IEnumerable<HamsterDto>> GetSpecificHamsterMatchData(int hamsterId)
        {
            var response = await _httpClient.GetAsync($"api/hamsters/matchwinners/{hamsterId}");
            
            if (!response.IsSuccessStatusCode)
                return null;
            
            var content = await response.Content.ReadAsStringAsync();
            
            var hamstersDefeated = JsonSerializer.Deserialize<IEnumerable<HamsterDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            return hamstersDefeated;
        }
    }
}
