using DAL.Model;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class RaceRepository : Repository<Race>, IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Race>> GetAllByCircuitIdAsync(int id)
        {
            return await _context.Races
                .Where(r => r.CircuitId == id)
                .ToListAsync();

        }

        public async Task<IEnumerable<Race>> GetAllBySeasonIdAsync(int id)
        {
            return await _context.Races
                .Where(r => r.SeasonId == id)
                .ToListAsync();
        }
    }
}
