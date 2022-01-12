using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Model
{

    public class Team
    {
        public int TeamNr { get; set; }

        public string Name { get; set; }
        public ICollection<RaceTeamPilot> RaceTeamPilots { get; set; }


    }
}
