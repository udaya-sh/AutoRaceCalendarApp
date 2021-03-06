using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Resources
{
    public class RaceResource
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CircuitId { get; set; }
        public int SeasonId { get; set; }
    }
}
