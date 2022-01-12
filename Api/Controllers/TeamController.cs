using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly TeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(TeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResource>>> GetAllTeams()
        {

            var teams = await _teamService.GetAllTeams();
            if (teams is not null)
            {
                var teamResources = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(teams);
                return Ok(teamResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<TeamResource>>> GetAllByPagination(int pageNr, int amount)
        {

            var teams = await _teamService.GetAllByPagination(pageNr, amount);
            if (teams is not null)
            {
                var teamResources = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(teams);
                return Ok(teamResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}/{searchString=}")]
        public async Task<ActionResult<IEnumerable<TeamResource>>> GetAllByPaginationAndSearchString(int pageNr, int amount, string searchString)
        {

            var teams = await _teamService.GetAllByPaginationAndSearchString(pageNr, amount, searchString);
            if (teams is not null)
            {
                var teamResources = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamResource>>(teams);
                return Ok(teamResources);

            }
            return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            var teamResource = _mapper.Map<Team, TeamResource>(team);
            if (teamResource is not null)
            {
                return Ok(teamResource);

            }
            return NotFound();
        }


        [HttpPost("addTeam")]
        public async Task<IActionResult> AddTeam(TeamResource team)
        {
            var toAddTeam = _mapper.Map<TeamResource, Team>(team);
            await _teamService.CreateTeam(toAddTeam);
            return Ok();

        }

        [HttpPost("updateTeam")]
        public async Task<IActionResult> UpdateTeam(TeamResource team)
        {
            var toUpdateTeam = _mapper.Map<TeamResource, Team>(team);
            await _teamService.UpdateTeam(toUpdateTeam);
            return Ok();
        }

        [HttpPost("deleteTeam/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeam(id);
            return Ok();
        }
    }
}
