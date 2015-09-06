namespace IsItABangerWeb.Migrations
{
    using IsItABangerWeb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IsItABangerWeb.DataAccess.BangerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IsItABangerWeb.DataAccess.BangerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Songs.AddOrUpdate(
                s => s.Name,
                new Song { Name = "I Will Wait", Artist = "Mumford and Sons", Bpm = 80, Drops = 0, DropsAreDope = false, HasAcousticInstruments = true, IsItABanger = false },
                new Song { Name = "Electroshark", Artist = "Yeah", Bpm = 120, Drops = 12, DropsAreDope = true, HasAcousticInstruments = false, IsItABanger = true }
            );
        }
    }
}
