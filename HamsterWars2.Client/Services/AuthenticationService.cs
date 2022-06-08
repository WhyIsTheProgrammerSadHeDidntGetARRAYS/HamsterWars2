using Blazored.LocalStorage;
using HamsterWars2.Client.Authentication;
using HamsterWars2.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.DataTransferObjects;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;


namespace HamsterWars2.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authState;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient,
            AuthenticationStateProvider authState,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authState = authState;
            _localStorage = localStorage;
        }

        public async Task<AuthenticatedUserModel> Login(UserAuthenticationDto user)
        {
            var authResult = await _httpClient.PostAsJsonAsync("api/authentication/login", user);

            if (!authResult.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await authResult.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<AuthenticatedUserModel>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //setting the jwt in local storage
            await _localStorage.SetItemAsync("token", result.Token);

            ((AuthStateProvider)_authState).NotifyUserAuthentication(result.Token);
            //_authStateProvider.NotifyUserAuthentication(result.Access_Token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);

            return result;
        }

        public async Task<RegistrationResponseDto> Register(UserRegistrationDto newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authentication/register", newUser);
                
            var content = await response.Content.ReadAsStringAsync();
            
            var result = JsonSerializer.Deserialize<RegistrationResponseDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            return result;
            
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((AuthStateProvider)_authState).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

    }
}
