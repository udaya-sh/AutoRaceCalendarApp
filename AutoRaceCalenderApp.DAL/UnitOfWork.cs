using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext context;
        private CircuitRepository _circuitRepository;
        private PilotRepository _pilotRepository;
        private RaceRepository _raceRepository;
        private SerieRepository _serieRepository;
        private RaceTeamPilotRepository _raceTeamPilotRepository;
        private SeasonRepository _seasonRepository;
        private TeamRepository _teamRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public ICircuitRepository Circuits => _circuitRepository ??= new CircuitRepository(context);

        public IPilotRepository Pilots => _pilotRepository ??= new PilotRepository(context);

        public IRaceRepository Races => _raceRepository ??= new RaceRepository(context);

        public IRaceTeamPilotRepository RaceTeamPilots => _raceTeamPilotRepository ??= new RaceTeamPilotRepository(context);

        public ISeasonRepository Seasons => _seasonRepository ??= new SeasonRepository(context);

        public ISerieRepository Series => _serieRepository ??= new SerieRepository(context);

        public ITeamRepository Teams => _teamRepository ??= new TeamRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);

        }
    }
}
