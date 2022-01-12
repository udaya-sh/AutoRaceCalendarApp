using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalenderApp.Model
{
    [Table(name: "Pilot")]
    public class Pilot
    {
        [Key]
        public long PilootId { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long LicenceNr { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string LastName { get; set; }


        [Column(TypeName = "varchar(50)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NickName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long Length { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long Weight { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PhotoPath { get; set; }
    }
}
