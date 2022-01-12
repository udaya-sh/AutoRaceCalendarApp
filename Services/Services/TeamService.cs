using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.BLL.Services
{
    public class TeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTeam(Team team)
        {
            await _unitOfWork.Teams.AddAsync(team);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _unitOfWork.Teams.GetAllAsync();
        }

        public async Task<IEnumerable<Team>> GetAllByPagination(int pageNumber, int amount)
        {
            return await _unitOfWork.Teams.GetAllByPagination(pageNumber, amount);
        }
        public async Task<IEnumerable<Team>> GetAllByPaginationAndSearchString(int pageNumber, int amount, string searchString)
        {
            return await _unitOfWork.Teams.GetAllByPaginationAndSearchString(pageNumber, amount, searchString);
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _unitOfWork.Teams.GetByIdAsync(id);
        }

        public async Task UpdateTeam(Team team)
        {
            _unitOfWork.Teams.Update(team);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTeam(int id)
        {
            var team = await GetTeamById(id);

            if (team is not null)
            {
                _unitOfWork.Teams.Remove(team);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
