using AutoMapper;
using AutoRaceCalendarApp.API.Resources;
using AutoRaceCalendarApp.BLL.Services;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : Controller
    {

        private readonly SerieService _serieService;
        private readonly IMapper _mapper;

        public SerieController(SerieService serieService, IMapper mapper )
        {
            _serieService = serieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerieResource>>> GetAllSeries()
        {

            var series = await _serieService.GetAllSeries();
            if(series is not null)
            {
                var serieResources = _mapper.Map<IEnumerable<Serie>, IEnumerable<SerieResource>>(series);
                return Ok(serieResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<SerieResource>>> GetAllByPagination(int pageNr, int amount )
        {

            var series = await _serieService.GetAllByPagination(pageNr, amount);
            if (series is not null)
            {
                var serieResources = _mapper.Map<IEnumerable<Serie>, IEnumerable<SerieResource>>(series);
                return Ok(serieResources);

            }
            return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieById(int id)
        { 
            var serie = await _serieService.GetSerieById(id);
            var serieResource = _mapper.Map<Serie, SerieResource>(serie);
            if (serieResource is not null)
            {
                return Ok(serieResource);

            }
            return NotFound();
        }

        [HttpGet("findByName/{name}")]
        public IActionResult GetSerieByName(string name)
        {
            var serie =  _serieService.GetSerieByName(name);
            var serieResource = _mapper.Map<Serie, SerieResource>(serie);
            if (serieResource is not null)
            {
                return Ok(serieResource);

            }
            return Ok(serie);
        }


        [HttpPost("addSerie")]
        public async Task<IActionResult> AddSerie(SerieResource serie )
        {
            var toAddSerie = _mapper.Map<SerieResource, Serie>(serie);
            var value = await _serieService.CreateSerie(toAddSerie);
            if (value is not null)
            {
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost("updateSerie")]
        public async Task<IActionResult> UpdateSerie(SerieResource serie)
        {
            var toUpdateSerie = _mapper.Map<SerieResource, Serie>(serie);
            await _serieService.UpdateSerie(toUpdateSerie);
            return Ok();
        }

        [HttpPost("deleteSerie/{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            await _serieService.DeleteSerie(id);
            return Ok();
        }
    }
}
