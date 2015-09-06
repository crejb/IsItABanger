using IsItABangerWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsItABangerWeb.DataAccess
{
    public class BangerDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Song> Songs
        {
            get
            {
                return Set<Song>();
            }
        }

        public static BangerDbContext Create()
        {
            return new BangerDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use custom schema for all tables in this app
            modelBuilder.HasDefaultSchema("Banger");
        }
    }
}