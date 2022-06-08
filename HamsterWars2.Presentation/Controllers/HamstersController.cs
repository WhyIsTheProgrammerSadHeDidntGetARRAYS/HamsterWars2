using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace HamsterWars2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamstersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public HamstersController(IServiceManager service)
        {
            _service = service;
        }
        
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetHamsters()
        {
            var hamsters = await _service.HamsterService.GetAllHamstersAsync(trackChanges: false);
            
            return Ok(hamsters);
        }
        [HttpGet("{id}", Name = "GetHamsterById")]
        public async Task<IActionResult> GetHamster(int id)
        {
            var hamster = await _service.HamsterService.GetHamsterByIdAsync(id, trackChanges: false);

            return Ok(hamster);
        }
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomHamster()
        {
            var hamster = await _service.HamsterService.GetRandomHamster(trackChanges: false);

            return Ok(hamster);
        }
        [HttpGet("hamstermatches")]
        public async Task<IActionResult> GetAllHamsterMatches()
        {
            var hamsters = await _service.HamsterService.GetAllHamsterMatches(trackChanges: false);
            
            if(hamsters == null)
            {
                return BadRequest("No data was retrieved from database");
            }
            
            return Ok(hamsters);
        }

        [HttpPost]
        public IActionResult CreateHamster([FromBody] CreateHamsterDto newHamsterDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var newHamster = _service.HamsterService.CreateHamsterAsync(newHamsterDto);

            //return CreatedAtRoute("GetHamsterById", new { id = newHamster.Id}, newHamster); //this seems odd.. 
            return StatusCode(201);
            //return Ok(newHamster);
        }
        [HttpGet("matchwinners/{winnerId}")]
        public async Task<IActionResult> GetSpecificHamsterWins(int winnerId)
        {
            var defeatedHamsters = await _service.HamsterService.GetSpecificHamsterWins(winnerId, trackChanges: false);

            return Ok(defeatedHamsters);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHamster(int id, [FromBody] UpdateHamsterDto updateHamsterDto)
        {
            if (updateHamsterDto == null)
                return BadRequest("Object was null");
            
            await _service.HamsterService.UpdateHamsterAsync(id, updateHamsterDto, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHamster(int id)
        {
            await _service.HamsterService.DeleteHamsterAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpGet("topfive")]
        public async Task<IActionResult> GetTopHamsters()
        {
            var hamsters = await _service.HamsterService.GetTopFiveHamstersAsync(trackChanges: false);

            return Ok(hamsters);
        }

        [HttpGet("bottomfive")]
        public async Task<IActionResult> GetBottomHamsters()
        {
            var hamsters = await _service.HamsterService.GetBottomFiveHamstersAsync(trackChanges: false);

            return Ok(hamsters);
        }
    }
}
