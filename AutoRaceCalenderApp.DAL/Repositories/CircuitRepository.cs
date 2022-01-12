using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class CircuitRepository : Repository<Circuit>, ICircuitRepository
    {
        private readonly ApplicationDbContext _context;

        public CircuitRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;

        }

        
        public async Task<Circuit> GetWithRaceByIdAsync(int id)
        {
            return await _context.Circuits
               .Include(m => m.Races)
               .SingleOrDefaultAsync(a => a.CircuitId == id);

        }
    }
}
