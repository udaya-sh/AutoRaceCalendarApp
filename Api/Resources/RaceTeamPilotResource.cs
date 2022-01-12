using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.API.Resources
{
    public class RaceTeamPilotResource
    {
        public int TeamNr { get; set; }
        public int RaceId { get; set; }
        public int PilotId { get; set; }
        public TeamResource Team { get; set; }
        public RaceResource Race { get; set; }
        public PilotResource Pilot { get; set; }
    }
}
