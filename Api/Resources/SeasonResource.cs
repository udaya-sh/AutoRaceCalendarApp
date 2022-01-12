using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Resources
{
    public class SeasonResource
    {
        public int SeasonId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public int SerieId { get; set; }

        public SerieResource Serie { get; set; }

    }
}
