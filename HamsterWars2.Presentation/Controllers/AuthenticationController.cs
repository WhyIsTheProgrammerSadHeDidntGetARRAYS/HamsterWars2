using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
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
    }
}
