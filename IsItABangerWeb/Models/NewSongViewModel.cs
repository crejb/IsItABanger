using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsItABangerWeb.Models
{
    public class NewSongViewModel
    {
        [Required]
        [Range(0, 500)]
        [Display(Name = "BPM")]
        public int Bpm { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "How many drops?")]
        public int Drops { get; set; }

        [Required]
        [UIHint("YesNo")]
        [Display(Name = "Are the drops dope?")]
        public bool DropsAreDope { get; set; }

        [Required]
        [UIHint("YesNo")]
        [Display(Name = "Are there any acoustic instruments?")]
        public bool HasAcousticInstruments { get; set; }
    }
}