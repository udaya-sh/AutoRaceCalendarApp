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
    public class SeasonController : Controller
    {

        private readonly SeasonService _seasonService;
        private readonly IMapper _mapper;

        public SeasonController(SeasonService seasonService, IMapper mapper)
        {
            _seasonService = seasonService;
            _mapper = mapper;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonResource>>> GetAllSeasons()
        {

            var seasons = await _seasonService.GetAllSeasons();
            if (seasons is not null)
            {
                var seasonResources = _mapper.Map<IEnumerable<Season>, IEnumerable<SeasonResource>>(seasons);
                return Ok(seasonResources);

            }
            return NotFound();

        }

        [HttpGet("getByPage/{pageNr}/{amount}")]
        public async Task<ActionResult<IEnumerable<SeasonResource>>> GetAllByPagination(int pageNr, int amount)
        {

            var seasons = await _seasonService.GetAllByPagination(pageNr, amount);
            if (seasons is not null)
            {
                var seasonResources = _mapper.Map<IEnumerable<Season>, IEnumerable<SeasonResource>>(seasons);
                return Ok(seasonResources);

            }
            return NotFound();

        }


        [HttpGet("getBySerieId/{serieId}")]
        public async Task<ActionResult<IEnumerable<SeasonResource>>> GetAllBySerieId(int serieId)
        {

            var seasons = await _seasonService.GetAllWithSerieId(serieId);
            if (seasons is not null)
            {
                var seasonResources = _mapper.Map<IEnumerable<Season>, IEnumerable<SeasonResource>>(seasons);
                return Ok(seasonResources);

            }
            return NotFound();

        }

        [HttpGet("{id}")]
        // GET: People/5
        public async Task<SeasonResource> GetSeasonById(int id)
        {
            var season = await _seasonService.GetSeasonById(id);
            return _mapper.Map<Season, SeasonResource>(season);
        }


        [HttpPost("addSeason")]
        public async Task<IActionResult> AddSeason(SeasonResource season)
        {
            var toAddSeason = _mapper.Map<SeasonResource, Season>(season);
            var value = await _seasonService.CreateSeason(toAddSeason);
            if (value is not null)
            {
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost("updateSeason")]
        public async Task<IActionResult> UpdateSeason(SeasonResource season)
        {
            var toUpdateSeason = _mapper.Map<SeasonResource, Season>(season);
            await _seasonService.UpdateSeason(toUpdateSeason);
            return Ok();
        }

        [HttpPost("deleteSeason/{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            await _seasonService.DeleteSeason(id);
            return Ok();
        }
    }
    
}
