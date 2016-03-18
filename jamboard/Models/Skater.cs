using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jamboard.Models
{
    public class Skater
    {
        public Skater()
        {
            IsSkating = false;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Why not just use an int? Because prior to 2015 WFTDA did allow alphabetic characters
        // and other leagues might still want to include characters. 
        // Plus, who does math on skater numbers anyway?
        [Required]
        [StringLength(10)]
        [Column(TypeName="varchar")]
        [RegularExpression(@"[0-9A-Z]{1,3}", ErrorMessage = "Number must be 1-3 digits or upper-case characters")]
        public string Number { get; set; }

        public bool IsSkating { get; set; }

        // [Required]
        // [Key]
        // [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        // many to many
        public virtual IList<Jam> Jams { get; set; }
    }
}