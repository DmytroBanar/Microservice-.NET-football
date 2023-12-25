using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        public readonly IFootballTeamService _teamService;
        public FootballTeamController(IFootballTeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTeamList()
        {
            var teamDetailsList = await _teamService.GetAllTeams();
            if(teamDetailsList == null)
            {
                return NotFound();
            }
            return Ok(teamDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{teamId}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            var teamDetails = await _teamService.GetTeamById(teamId);

            if (teamDetails != null)
            {
                return Ok(teamDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTeam(FootballTeamDetails teamDetails)
        {
            var isTeamCreated = await _teamService.CreateTeam(teamDetails);

            if (isTeamCreated)
            {
                return Ok(isTeamCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(FootballTeamDetails teamDetails)
        {
            if (teamDetails != null)
            {
                var isTeamCreated = await _teamService.UpdateTeam(teamDetails);
                if (isTeamCreated)
                {
                    return Ok(isTeamCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var isTeamCreated = await _teamService.DeleteTeam(teamId);

            if (isTeamCreated)
            {
                return Ok(isTeamCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
