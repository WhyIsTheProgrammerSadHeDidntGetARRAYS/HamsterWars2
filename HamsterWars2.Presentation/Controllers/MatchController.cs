using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWars2.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MatchController(IServiceManager service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _service.MatchDataService.GetAllMatchesAsync(trackChanges: false);

            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _service.MatchDataService.GetMatchAsync(id, trackChanges: false);

            return Ok(match);
        }
    }
}
