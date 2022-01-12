using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPilotRepository : IRepository<Pilot>
    {
        Task<Pilot> GetWithRaceTeamPilotByIdAsync(int id);

    }
}
