using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Models
{
    public class SeasonRaceViewModel
    {
        public SeasonViewModel Season;
        public IEnumerable<RaceViewModel> Races;

        public SeasonRaceViewModel(SeasonViewModel season, IEnumerable<RaceViewModel> races)
        {
            Season = season;
            Races = races;
        }
    }
}
