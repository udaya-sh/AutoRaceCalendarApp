using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;
        private readonly IMapper _mapper;

        public RaceController(RaceService raceService, IMapper mapper)
        {
            _raceService = raceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResource>>> GetAllRaces()
        {

            var races = await _raceService.GetAllRaces();
            if (races is not null)
            {
                var raceResources = _mapper.Map<IEnumerable<Race>, IEnumerable<RaceResource>>(races);
                return Ok(raceResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<RaceResource>>> GetAllByPagination(int pageNumber, int amount)
        {

            var races = await _raceService.GetAllByPagination(pageNumber, amount);
            if (races is not null)
            {
                var raceResources = _mapper.Map<IEnumerable<Race>, IEnumerable<RaceResource>>(races);
                return Ok(raceResources);

            }
            return NotFound();

        }


        [HttpGet("getBySeasonId/{seasonId}")]
        public async Task<ActionResult<IEnumerable<RaceResource>>> GetAllBySerieId(int seasonId)
        {

            var races = await _raceService.GetAllBySeasonId(seasonId);
            if (races is not null)
            {
                var raceResources = _mapper.Map<IEnumerable<Race>, IEnumerable<RaceResource>>(races);
                return Ok(raceResources);

            }
            return NotFound();

        }

        [HttpGet("getByCircuitId/{circuitId}")]
        public async Task<ActionResult<IEnumerable<RaceResource>>> GetAllByCircuitId(int circuitId)
        {

            var races = await _raceService.GetAllByCircuitId(circuitId);
            if (races is not null)
            {
                var raceResources = _mapper.Map<IEnumerable<Race>, IEnumerable<RaceResource>>(races);
                return Ok(raceResources);

            }
            return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<RaceResource> GetRaceById(int id)
        {
            var race = await _raceService.GetRaceById(id);
            return _mapper.Map<Race, RaceResource>(race);
        }


        [HttpPost("addRace")]
        public async Task<IActionResult> AddRace(RaceResource race)
        {
            var toAddRace = _mapper.Map<RaceResource, Race>(race);
            await _raceService.CreateRace(toAddRace);
            return Ok();

        }

        [HttpPost("updateRace")]
        public async Task<IActionResult> UpdateRace(RaceResource race)
        {
            var toUpdateRace = _mapper.Map<RaceResource, Race>(race);
            await _raceService.UpdateRace(toUpdateRace);
            return Ok();
        }

        [HttpPost("deleteRace/{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            await _raceService.DeleteRace(id);
            return Ok();
        }

    }
}
