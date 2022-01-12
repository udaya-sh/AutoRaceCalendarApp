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
    class SerieRepository : Repository<Serie>, ISerieRepository
    {
        private readonly ApplicationDbContext _context;

        public SerieRepository(ApplicationDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public Serie GetByName(string name)
        {          
            var serie  = _context.Series
                .Where(s => s.Name == name)
                .FirstOrDefault();

            if (serie != null)
            {
                return serie;
            }
            {
                return null;
            }           
        }

        
        public override async Task<IEnumerable<Serie>> GetAllByPagination(int pageNumber, int amount)
        {

            return await _context.Series
                
                .OrderBy(s => s.SortOrder == null)
                .ThenBy(s => s.SortOrder)
                .ThenBy(s => s.Name)
                .Skip((pageNumber - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }
    }
}
