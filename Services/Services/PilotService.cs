using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class PilotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PilotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePilot(Pilot pilot)
        {
            await _unitOfWork.Pilots.AddAsync(pilot);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IEnumerable<Pilot>> GetAllPilots()
        {
            return await _unitOfWork.Pilots.GetAllAsync();
        }

        public async Task<IEnumerable<Pilot>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.Pilots.GetAllByPagination(pageNumber, amount);
        }

        public async Task<Pilot> GetPilotById(int id)
        {
            return await _unitOfWork.Pilots.GetByIdAsync(id);
        }

        public async Task UpdatePilot(Pilot pilot)
        {
            _unitOfWork.Pilots.Update(pilot);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePilot(int id)
        {
            var pilot = await GetPilotById(id);

            if (pilot is not null)
            {
                _unitOfWork.Pilots.Remove(pilot);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
