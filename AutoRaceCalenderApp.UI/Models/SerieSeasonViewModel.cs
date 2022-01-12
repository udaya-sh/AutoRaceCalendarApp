using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Models
{
    public class SerieSeasonViewModel
    {
        public SerieViewModel Serie;
        public ICollection<SeasonViewModel> Seasons;

        public SerieSeasonViewModel(SerieViewModel serie, ICollection<SeasonViewModel> seasons)
        {
            Serie = serie;
            Seasons = seasons;
        }


    }
}
