namespace jamboard.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<jamboard.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "jamboard.Models.ApplicationDbContext";
        }

        private const int IdDCRG = 1;
        private const int IdGGB = 2;

        protected override void Seed(jamboard.Models.ApplicationDbContext db)
        {
            //  This method will be called after migrating to the latest version.
            db.Teams.AddOrUpdate(t => t.Id,
                new Team { Id = IdDCRG, Name = "Derby City Rollergirls", ShortName = "DCRG" },
                new Team { Id = IdGGB,  Name = "Garnet Grit Betties",    ShortName = "GGB" });

            db.Skaters.AddOrUpdate(s => s.Id,
                new Skater { Name = "Nancy", Number = "88", TeamId = IdDCRG });

            db.SaveChanges();
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
        }
    }
}
