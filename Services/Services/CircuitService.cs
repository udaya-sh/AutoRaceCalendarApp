using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class CircuitService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public CircuitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCircuit(Circuit circuit)
        {
            await _unitOfWork.Circuits.AddAsync(circuit);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCircuit(int id)
        {
            var circuit = await GetCircuitById(id);

            if (circuit is not null)
            {
                _unitOfWork.Circuits.Remove(circuit);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<Circuit>> GetAllCircuits()
        {
            return await _unitOfWork.Circuits.GetAllAsync();
        }

        public async Task<Circuit> GetCircuitById(int id)
        {
            return await _unitOfWork.Circuits.GetByIdAsync(id);
        }

        public async Task UpdateCircuit(Circuit circuit)
        {
            _unitOfWork.Circuits.Update(circuit);
            await _unitOfWork.CommitAsync();
        }


    }
}
