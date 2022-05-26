using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<User> userManager, IMapper mapper,
            ILoggerManager logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, createUserDto.Roles);

            return result;
        }
    }
}
