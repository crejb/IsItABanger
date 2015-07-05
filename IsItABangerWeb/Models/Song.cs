using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsItABangerWeb.Models
{
    public class Song
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        
        [Required]
        [Range(0, 500)]
        
        public int Bpm { get; set; }

        [Required]
        [Range(0, 100)]
        public int Drops { get; set; }

        [Required]
        [UIHint("YesNo")]
        public bool DropsAreDope { get; set; }

        [Required]
        [UIHint("YesNo")]
        public bool HasAcousticInstruments { get; set; }

        [UIHint("YesNo")]
        public bool IsItABanger { get; set; }
    }

    public class BangerDbContext : ApplicationDbContext
    {
        public DbSet<Song> Songs
        {
            get
            {
                return Set<Song>();
            }
        }
    }
}