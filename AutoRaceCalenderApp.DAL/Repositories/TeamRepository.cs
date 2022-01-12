using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL.Repositories
{
    class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context) 
            : base(context) 
        {
            _context = context;
        }


        public Team GetByName(string name)
        {
            var team = _context.Teams
                .Where(s => s.Name == name)
                .FirstOrDefault();

            if (team != null)
            {
                return team;
            }
            {
                return null;
            }
        }

        public async Task<IEnumerable<Team>> GetAllByPaginationAndSearchString(int pageNumber, int amount, string searchString)
        {


            if (searchString is null)
            {
                return await _context.Teams
                   .OrderBy(t => t.Name)
                   .Skip((pageNumber - 1) * amount)
                   .Take(amount)
                   .ToListAsync();
            }
            else
            {
                return await _context.Teams
                    .OrderBy(t => t.Name)
                    .Where(t => t.Name.Contains(searchString))
                    .Skip((pageNumber - 1) * amount)
                    .Take(amount)
                    .ToListAsync();
            }
        }

        
    }
}
