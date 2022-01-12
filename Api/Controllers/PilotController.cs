using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalenderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotController : Controller
    {
        private readonly PilotService _pilotService;
        private readonly IMapper _mapper;
        public PilotController(PilotService pilotService, IMapper mapper)
        {
            _pilotService = pilotService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PilotResource>>> GetAllPilots()
        {
            var pilots = await _pilotService.GetAllPilots();
            var pilotResources = _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotResource>>(pilots);
            if (pilotResources is not null)
            {
                return Ok(pilotResources);
            }
            return NotFound();
        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<PilotResource>>> GetAllPilotsByPage(int pageNr, int amount)
        {
            var pilots = await _pilotService.GetAllByPagination(pageNr, amount);
            var pilotResources = _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotResource>>(pilots);
            if (pilotResources is not null)
            {
                return Ok(pilotResources);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPilotById(int id)
        {
            var pilot = await _pilotService.GetPilotById(id);
            var pilotResource = _mapper.Map<Pilot, PilotResource>(pilot);

            if(pilotResource is not null)
            {
                return Ok(pilotResource);
            }
            return NotFound();
        }


        [HttpPost("addPilot")]
        public async Task<IActionResult> AddPilot(PilotResource pilot)
        {
            var toAddPilot = _mapper.Map<PilotResource, Pilot>(pilot);
            await _pilotService.CreatePilot(toAddPilot);
            return Ok();

        }

        [HttpPost("updatePilot")]
        public async Task<IActionResult> UpdatePilot(PilotResource pilot)
        {
            var toUpdatePilot = _mapper.Map<PilotResource, Pilot>(pilot);
            await _pilotService.UpdatePilot(toUpdatePilot);
            return Ok();
        }

        [HttpPost("deletePilot/{id}")]
        public async Task<IActionResult> DeletePilot(int id)
        {
            await _pilotService.DeletePilot(id);
            return Ok();
        }
    }
}
