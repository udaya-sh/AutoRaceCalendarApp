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
    class SeasonRepository : Repository<Season>, ISeasonRepository
    {
        private readonly ApplicationDbContext _context;

        public SeasonRepository(ApplicationDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Season>> GetAllWithSerieIdAsync(int id)
        {
            return await _context.Seasons
                 .Include(s => s.Serie)
                 .Where(s => s.SerieId == id)
                 .ToListAsync();
        }
        public Season GetByName(string name)
        {
            var season = _context.Seasons
                .Where(s => s.Name == name)
                .FirstOrDefault();

            if (season != null)
            {
                return season;
            }
            {
                return null;
            }
        }


        public override async Task<IEnumerable<Season>> GetAllByPagination(int pageNumber, int amount)
        {

            return await _context.Seasons
                .Include(s => s.Serie)
                .OrderByDescending(s => s.StartDate)
                .Skip((pageNumber - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }
    }
}
