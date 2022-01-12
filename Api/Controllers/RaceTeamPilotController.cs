using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RaceTeamPilotController : Controller
    {
        private readonly RaceTeamPilotService _raceTeamPilotServiceService;
        private readonly IMapper _mapper;

        public RaceTeamPilotController(RaceTeamPilotService raceTeamPilotServiceService, IMapper mapper)
        {
            _raceTeamPilotServiceService = raceTeamPilotServiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceTeamPilotResource>>> GetAllRaceTeamPilots()
        {

            var raceTeamPilotServices = await _raceTeamPilotServiceService.GetAllRaceTeamPilots();
            if (raceTeamPilotServices is not null)
            {
                var raceTeamPilotServiceResources = _mapper.Map<IEnumerable<RaceTeamPilot>, IEnumerable<RaceTeamPilotResource>>(raceTeamPilotServices);
                return Ok(raceTeamPilotServiceResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<RaceTeamPilotResource>>> GetAllByPagination(int pageNr, int amount)
        {

            var raceTeamPilotServices = await _raceTeamPilotServiceService.GetAllByPagination(pageNr, amount);
            if (raceTeamPilotServices is not null)
            {
                var raceTeamPilotServiceResources = _mapper.Map<IEnumerable<RaceTeamPilot>, IEnumerable<RaceTeamPilotResource>>(raceTeamPilotServices);
                return Ok(raceTeamPilotServiceResources);

            }
            return NotFound();

        }

        [HttpPost("{raceId}/{teamNr}/{pilotId}")]
        public async Task<IActionResult> GetRaceTeamPilotByAllId(int raceId, int pilotId, int teamNr)
        {
            var raceTeamPilotService = await _raceTeamPilotServiceService.GetRaceTeamPilotByAllId(raceId,pilotId,teamNr);
            var raceTeamPilotServiceResource = _mapper.Map<RaceTeamPilot, RaceTeamPilotResource>(raceTeamPilotService);
            if (raceTeamPilotServiceResource is not null)
            {
                return Ok(raceTeamPilotServiceResource);

            }
            return NotFound();
        }


        [HttpPost("addRaceTeamPilot")]
        public async Task<IActionResult> AddRaceTeamPilot(RaceTeamPilotResource raceTeamPilotService)
        {
            var toAddRaceTeamPilot = _mapper.Map<RaceTeamPilotResource, RaceTeamPilot>(raceTeamPilotService);
            await _raceTeamPilotServiceService.CreateRaceTeamPilot(toAddRaceTeamPilot);
            return Ok();

        }

        [HttpPost("updateRaceTeamPilot")]
        public async Task<IActionResult> UpdateRaceTeamPilot(RaceTeamPilotResource raceTeamPilotService)
        {
            var toUpdateRaceTeamPilot = _mapper.Map<RaceTeamPilotResource, RaceTeamPilot>(raceTeamPilotService);
            await _raceTeamPilotServiceService.UpdateRaceTeamPilot(toUpdateRaceTeamPilot);
            return Ok();
        }

        [HttpPost("deleteRaceTeamPilot/{raceId}/{teamNr}/{pilotId}")]
        public async Task<IActionResult> DeleteRaceTeamPilot(int raceId, int teamNr, int pilotId )
        {
            await _raceTeamPilotServiceService.DeleteRaceTeamPilot(raceId,pilotId,teamNr);
            return Ok();
        }
    }
}
