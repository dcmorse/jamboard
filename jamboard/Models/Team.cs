using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;

namespace jamboard.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // "Derby City Roller Girls"
        [Required]
        public string ShortName { get; set; } // "DCRG"
        [Required]
        public uint FGColor { get; set; } // 0xFF0000 aka red
        [Required]
        public uint BGColor { get; set; } // 0x000000 aka black
        //[Key]
        //[ForeignKey("Skater")]
        //public virtual List<int> SkaterID { get; set; }
        public virtual IList<Skater> Skaters { get; set; }
        public virtual IList<Jam> Jams { get; set; }
    }
}