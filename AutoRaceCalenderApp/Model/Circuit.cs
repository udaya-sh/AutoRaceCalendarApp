using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalenderApp.Model
{
    [Table(name: "Circuit")]
    public class Circuit
    {
        [Key]
        public long CircuitID { get; set; }

        [Column(TypeName ="varchar(50)")]
        [Required]
        public string Land { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Stad { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Straat { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int StraatNr { get; set; }
    }
}
