using System;


namespace AutoRaceCalendarApp.UI.Models
{
    public class SerieViewModel
    {
        
        public int SerieId { get; set; }
        public int? SortOrder { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

       
    }
}
