using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL.Repositories
{
    class RaceTeamPilotRepository : Repository<RaceTeamPilot>, IRaceTeamPilotRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceTeamPilotRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByPilotIdAsync(int pilotId)
        {
            return await _context.RaceTeamPilots
                .Where(rtp => rtp.PilotId == pilotId)
                .ToListAsync();
        }        

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByRaceIdtAsync(int raceId)
        {
            return await _context.RaceTeamPilots
                .Where(rtp => rtp.RaceId == raceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByTeamNrAsync(int teamNr)
        {
            return await _context.RaceTeamPilots
                .Where(rtp => rtp.TeamNr == teamNr)
                .ToListAsync();
        }

        public async Task<RaceTeamPilot> GetByAll(int teamNr, int pilotId, int raceId)
        {
            return await _context.RaceTeamPilots
                .Where(rtp => rtp.TeamNr == teamNr)
                .Where(rtp => rtp.PilotId == pilotId)
                .Where(rtp => rtp.RaceId == raceId)
                .SingleAsync();
        }
    }
}
