using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<IEnumerable<Team>> GetAllByPaginationAndSearchString(int pageNr, int amount, string searchString);
        Team GetByName(string name);

    }
}
