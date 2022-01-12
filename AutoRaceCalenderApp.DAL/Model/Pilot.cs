using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Model
{

    public class Pilot
    {

        public int PilootId { get; set; }

        public int LicenceNr { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string NickName { get; set; }
   
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Length { get; set; }

        public double Weight { get; set; }

        public string PhotoPath { get; set; }
        public ICollection<RaceTeamPilot> RaceTeamPilots { get; set; }

    }
}
