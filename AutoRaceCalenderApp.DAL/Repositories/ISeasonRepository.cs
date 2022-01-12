using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;


namespace DAL.Repositories
{
    public interface ISeasonRepository : IRepository<Season>
    {
        Task<IEnumerable<Season>> GetAllWithSerieIdAsync(int id);
        Season GetByName(string name);

    }
}
