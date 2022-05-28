using Shared.DataTransferObjects;
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
                throw new ApplicationException("Failed to fetch hamsters from server.");

            var content = await response.Content.ReadAsStringAsync();

            var hamsters = JsonSerializer.Deserialize<IEnumerable<HamsterDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return hamsters;
        }
        public async Task<HamsterDto> GetRandomHamsterAsync()
        {
            var response = await _httpClient.GetAsync("api/hamsters/random"); //TODO: should probably not hardcode uri's
            
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("The response from the server failed");
            
            var content = await response.Content.ReadAsStringAsync();
            
            var hamster = JsonSerializer.Deserialize<HamsterDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 
            
            return hamster;

        }
    }
}
