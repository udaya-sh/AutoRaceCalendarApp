﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalenderApp.Model
{
    [Table(name: "Serie")]
    public class Serie
    {
        [Key]
        public long SerieId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime EndDate { get; set; }
    }
}
