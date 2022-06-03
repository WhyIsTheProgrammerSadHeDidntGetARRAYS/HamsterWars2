using HamsterWars2.Client.Models;
using Shared.DataTransferObjects;

namespace HamsterWars2.Client.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> Login(UserAuthenticationDto user);
        Task<RegistrationResponseDto> Register(UserRegistrationDto newUser);
        Task Logout();
    }
}