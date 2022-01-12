using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Model
{

    public class Season
    {

        public int SeasonId { get; set; }

        public string Name { get; set; }
    
        public DateTime StartDate { get; set; }
   
        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public int SerieId { get; set; }

        public Serie Serie { get; set; }

        public ICollection<Race> Races { get; set; }


    }
}
