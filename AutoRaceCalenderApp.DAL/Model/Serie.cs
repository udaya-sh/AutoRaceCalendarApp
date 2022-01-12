using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Model
{

    public class Serie
    {
        public int SerieId { get; set; }

        public int? SortOrder { get; set; }

        public string Name { get; set; }
  
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<Season> Seasons { get; set; }
    }
}
