using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;


namespace DAL.Repositories
{
    public interface IRaceTeamPilotRepository : IRepository<RaceTeamPilot>
    {
        Task<IEnumerable<RaceTeamPilot>> GetAllByTeamNrAsync(int teamId);
        Task<IEnumerable<RaceTeamPilot>> GetAllByPilotIdAsync(int pilotId);
        Task<IEnumerable<RaceTeamPilot>> GetAllByRaceIdtAsync(int raceId);
        Task<RaceTeamPilot> GetByAll(int teamId, int pilotId, int raceId);
    }
}
