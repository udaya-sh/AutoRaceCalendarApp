using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : Controller
    {
        private readonly IMapper _mapper;
        private readonly CircuitService _circuitService;


        public CircuitController(CircuitService circuitService, IMapper mapper)
        {
            _circuitService = circuitService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CircuitResource>>> GetAllCircuits()
        {
            var circuits = await _circuitService.GetAllCircuits();
            var circuitResources = _mapper.Map<IEnumerable<Circuit>, IEnumerable<CircuitResource>>(circuits);
            return Ok(circuitResources);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CircuitResource>> GetCircuitById(int id)
        {
            var circuit = await _circuitService.GetCircuitById(id);
            var circuitResource = _mapper.Map<Circuit, CircuitResource>(circuit);
            return Ok(circuitResource);

        }

        [HttpPost("addCircuit")]
        public async Task<IActionResult> AddCircuit(CircuitResource circuitResource)
        {
            var circuit = _mapper.Map<CircuitResource, Circuit>(circuitResource);
            await _circuitService.CreateCircuit(circuit);
            return Ok();
        }

        [HttpPost("updateCircuit")]
        public async Task<IActionResult> UpdateCircuit(CircuitResource circuitResource)
        {
            var circuit = _mapper.Map<CircuitResource, Circuit>(circuitResource);
            await _circuitService.UpdateCircuit(circuit);
            return Ok();
        }

        [HttpPost("deleteCircuit/{id}")]
        public async Task<IActionResult> DeleteCircuit(int id)
        {
            await _circuitService.DeleteCircuit(id);
            return Ok();
        }

    }
}
