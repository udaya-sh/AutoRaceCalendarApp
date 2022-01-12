using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class RaceTeamPilot
    {
        public int TeamNr { get; set; }
        public int RaceId { get; set; }
        public int PilotId { get; set; }
        public Team Team { get; set; }
        public Race Race { get; set; }
        public Pilot Pilot { get; set; }
    }
}
