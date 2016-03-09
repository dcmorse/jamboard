using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jamboard.Models
{
    public class Skater
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Why not just use an int? Because prior to 2015 WFTDA did allow alphabetic characters
        // and other leagues might still want to include characters. 
        // Plus, who does math on skater numbers anyway?
        [Required]
        [RegularExpression(@"[0-9A-Z]{2,3}", ErrorMessage = "Number must be 2-3 digits or upper-case characters")]
        public string Number { get; set; }
    }
}