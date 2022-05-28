﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace HamsterWars2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto createUserDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _service.AuthenticationService.RegisterUser(createUserDto);
            if (!result.Succeeded)
            {
                return BadRequest("Modelstate invalid");
            }
            return StatusCode(201);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationDto user)
        {
            var validateUser = await _service.AuthenticationService.ValidateUser(user);
            
            if(!validateUser)
                return Unauthorized();
            
            return Ok(new { Token = await _service.AuthenticationService.CreateToken() }); // this should probably return a custom response message? not sure
        }
    }
}
