using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Models.Team
{
    public class TeamViewModel
    {
  
        public int TeamNr { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
