using DAL.Model;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PilotRepository : Repository<Pilot>, IPilotRepository
    {
        private readonly ApplicationDbContext _context;
        public PilotRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Pilot> GetWithRaceTeamPilotByIdAsync(int id)
        {
            return await _context.Pilots
               .Include(m => m.RaceTeamPilots)
               .SingleOrDefaultAsync(a => a.PilootId == id);

        }
    }
}
