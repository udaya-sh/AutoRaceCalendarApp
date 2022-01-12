using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;


namespace DAL.Repositories
{
    public interface IRaceRepository : IRepository<Race>
    {
        Task<IEnumerable<Race>> GetAllByCircuitIdAsync(int id);
        Task<IEnumerable<Race>> GetAllBySeasonIdAsync(int id);

    }
}
