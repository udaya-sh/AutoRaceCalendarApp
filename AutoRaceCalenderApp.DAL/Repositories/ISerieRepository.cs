using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;


namespace DAL.Repositories
{
    public interface ISerieRepository : IRepository<Serie>
    {
        Serie GetByName(string name);

    }
}
