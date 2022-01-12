using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class SerieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SerieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> CreateSerie(Serie serie)
        {
            var exist = GetSerieByName(serie.Name);
            if(exist ==null)
            {
                await _unitOfWork.Series.AddAsync(serie);
                await _unitOfWork.CommitAsync();

                return "added";
            }
            else return null;
        }

        public async Task<IEnumerable<Serie>> GetAllSeries()
        {
            return await _unitOfWork.Series.GetAllAsync();
        }
        public async Task<IEnumerable<Serie>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.Series.GetAllByPagination(pageNumber, amount);
        }

        public async Task<Serie> GetSerieById(int id)
        {
            return await _unitOfWork.Series.GetByIdAsync(id);
        }

        public  Serie GetSerieByName(string name)
        {
            return _unitOfWork.Series.GetByName(name);
        }

        public async Task UpdateSerie(Serie serie)
        {
            _unitOfWork.Series.Update(serie);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteSerie(int id)
        {
            var serie = await GetSerieById(id);

            if(serie is not null)
            {
                _unitOfWork.Series.Remove(serie);
                await _unitOfWork.CommitAsync();
            }
        }

    }
}
