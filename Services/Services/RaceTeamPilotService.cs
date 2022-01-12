using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class RaceTeamPilotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RaceTeamPilotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateRaceTeamPilot(RaceTeamPilot team)
        {
            await _unitOfWork.RaceTeamPilots.AddAsync(team);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllRaceTeamPilots()
        {
            return await _unitOfWork.RaceTeamPilots.GetAllAsync();
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.RaceTeamPilots.GetAllByPagination(pageNumber, amount);
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByRaceId(int raceId)
        {
            return await _unitOfWork.RaceTeamPilots.GetAllByRaceIdtAsync(raceId);
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByPilotId(int pilotId)
        {
            return await _unitOfWork.RaceTeamPilots.GetAllByPilotIdAsync(pilotId);
        }

        public async Task<IEnumerable<RaceTeamPilot>> GetAllByTeamNr(int teamNr)
        {
            return await _unitOfWork.RaceTeamPilots.GetAllByTeamNrAsync(teamNr);
        }

        public async Task<RaceTeamPilot> GetRaceTeamPilotByAllId(int raceId, int pilotId, int teamNr)
        {
            return await _unitOfWork.RaceTeamPilots.GetByAll(teamNr, pilotId, raceId);
        }

        public async Task UpdateRaceTeamPilot(RaceTeamPilot team)
        {
            _unitOfWork.RaceTeamPilots.Update(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRaceTeamPilot(int raceId, int pilotId, int teamNr)
        {
            var raceTeamPilotToDelete = await _unitOfWork.RaceTeamPilots.GetByAll(teamNr,pilotId,raceId);
            if (raceTeamPilotToDelete is null)
            {
                throw new Exception("RaceTeamPilot could not be found.");
            }
            else
            {
                _unitOfWork.RaceTeamPilots.Remove(raceTeamPilotToDelete);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
