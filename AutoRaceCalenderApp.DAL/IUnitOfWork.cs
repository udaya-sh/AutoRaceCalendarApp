using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICircuitRepository Circuits { get; }
        IPilotRepository Pilots { get; }
        IRaceRepository Races { get; }
        IRaceTeamPilotRepository RaceTeamPilots { get; }
        ISeasonRepository Seasons { get; }
        ISerieRepository Series { get; }
        ITeamRepository Teams { get; }
        Task<int> CommitAsync();
       
    

    }
}
