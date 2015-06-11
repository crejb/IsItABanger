using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsItABangerWeb.Models
{
    public interface IBangerCalculator
    {
        void SetBanger(Song song);
    }

    public interface IBangerStrategy
    {
        bool CalculateIsItABanger(Song song);
    }

    public class BangerCalculator : IBangerCalculator
    {
        private readonly IBangerStrategy _strategy;

        public BangerCalculator(IBangerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetBanger(Song song)
        {
            song.IsItABanger = _strategy.CalculateIsItABanger(song);
        }
    }

    public class HaverfordBangerStrategy : IBangerStrategy
    {
        public bool CalculateIsItABanger(Song song)
        {
            return song.Bpm > 100 &&
                song.Drops > 0 &&
                song.DropsAreDope &&
                !song.HasAcousticInstruments &&
                song.Artist != "The Lumineers";
        }
    }
}