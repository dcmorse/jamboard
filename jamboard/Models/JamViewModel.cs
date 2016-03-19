using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jamboard.Models
{


//    public class ExternalLoginConfirmationViewModel
//    {
//        [Required]
//        [Display(Name = "Email")]
//        public string Email { get; set; }
//    }

    public class JamViewModel
    {
        public JamViewModel()
        {
            SelectedSkaters = new List<int>();
        }

        [Required]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual IList<Skater> AllSkaters { get; set; }

        public List<int> SelectedSkaters { get; set; }
    }
}