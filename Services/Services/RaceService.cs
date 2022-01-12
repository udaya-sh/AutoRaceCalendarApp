using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class RaceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateRace(Race race)
        {
            await _unitOfWork.Races.AddAsync(race);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRaces()
        {
            return await _unitOfWork.Races.GetAllAsync();
        }
        public async Task<IEnumerable<Race>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.Races.GetAllByPagination(pageNumber, amount);
        }

        public async Task<IEnumerable<Race>> GetAllBySeasonId(int seasonId)
        {
            return await _unitOfWork.Races.GetAllBySeasonIdAsync(seasonId);
        }

        public async Task<IEnumerable<Race>> GetAllByCircuitId(int circuitId)
        {
            return await _unitOfWork.Races.GetAllByCircuitIdAsync(circuitId);
        }

        public async Task<Race> GetRaceById(int id)
        {
            return await _unitOfWork.Races.GetByIdAsync(id);
        }

        public async Task UpdateRace(Race race)
        {
            _unitOfWork.Races.Update(race);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRace(int id)
        {
            var race = await GetRaceById(id);

            if (race is not null)
            {
                _unitOfWork.Races.Remove(race);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
