using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class SeasonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeasonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> CreateSeason(Season season)
        {
            var seasonExist = GetSeasonByName(season.Name);
            if (seasonExist is null)
            {
                await _unitOfWork.Seasons.AddAsync(season);
                await _unitOfWork.CommitAsync();
                return "added";
            }
            else return null;

        }

        public Season GetSeasonByName(string name)
        {
            return _unitOfWork.Seasons.GetByName(name);
        }

        public async Task<IEnumerable<Season>> GetAllSeasons()
        {
            return await _unitOfWork.Seasons.GetAllAsync();
        }
        public async Task<IEnumerable<Season>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.Seasons.GetAllByPagination(pageNumber, amount);
        }

        public async Task<IEnumerable<Season>> GetAllWithSerieId(int serie)
        {
            return await _unitOfWork.Seasons.GetAllWithSerieIdAsync(serie);
        }


        public async Task<Season> GetSeasonById(int id)
        {
            return await _unitOfWork.Seasons.GetByIdAsync(id);
        }

        public async Task UpdateSeason(Season season)
        {
            _unitOfWork.Seasons.Update(season);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSeason(int id)
        {
            var season = await GetSeasonById(id);

            if (season is not null)
            {
                _unitOfWork.Seasons.Remove(season);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
