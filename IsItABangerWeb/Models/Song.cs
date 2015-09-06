using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsItABangerWeb.Models
{
    public class Song
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }
        
        [Required]
        [Range(0, 500)]
        [Display(Name = "How many Beats Per Minute?")]
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

        [UIHint("YesNo")]
        public bool IsItABanger { get; set; }
    }
}