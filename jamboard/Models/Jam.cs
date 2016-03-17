using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jamboard.Models
{
    public class Jam
    {
        public Jam()
        {
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }

        // they are per-team because there is one person per team doing data entry at line-up
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        // many-to-many
        public virtual IList<Skater> Skaters { get; set; }

        public DateTime Timestamp { get; set; }
    }
}