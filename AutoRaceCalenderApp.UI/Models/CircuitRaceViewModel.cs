using AutoRaceCalenderApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Models
{
    public class CircuitRaceViewModel
    {
        public CircuitViewModel Circuit;
        public IEnumerable<RaceViewModel> Races;

        public CircuitRaceViewModel(CircuitViewModel circuit, IEnumerable<RaceViewModel> races)
        {
            Circuit = circuit;
            Races = races;
        }
    }
}
