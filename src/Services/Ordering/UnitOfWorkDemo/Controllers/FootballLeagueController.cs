using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballLeagueController : ControllerBase
    {
        public readonly IFootballLeagueService _leagueService;
        public FootballLeagueController(IFootballLeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeagueList()
        {
            var leagueDetailsList = await _leagueService.GetAllLeagues();
            if (leagueDetailsList == null)
            {
                return NotFound();
            }
            return Ok(leagueDetailsList);
        }

        [HttpGet("{leagueId}")]
        public async Task<IActionResult> GetLeagueById(int leagueId)
        {
            var leagueDetails = await _leagueService.GetLeagueById(leagueId);

            if (leagueDetails != null)
            {
                return Ok(leagueDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeague(FootballLeagueDetails leagueDetails)
        {
            var isLeagueCreated = await _leagueService.CreateLeague(leagueDetails);

            if (isLeagueCreated)
            {
                return Ok(isLeagueCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLeague(FootballLeagueDetails leagueDetails)
        {
            if (leagueDetails != null)
            {
                var isLeagueCreated = await _leagueService.UpdateLeague(leagueDetails);
                if (isLeagueCreated)
                {
                    return Ok(isLeagueCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{leagueId}")]
        public async Task<IActionResult> DeleteLeague(int leagueId)
        {
            var isLeagueCreated = await _leagueService.DeleteLeague(leagueId);

            if (isLeagueCreated)
            {
                return Ok(isLeagueCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
