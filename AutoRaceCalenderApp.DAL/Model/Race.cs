using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Model
{

    public class Race
    {
  
        public int RaceId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CircuitId { get; set; }
        public Circuit Circuit { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public ICollection<RaceTeamPilot> RaceTeamPilots { get; set; }


    }
}
