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
                new Skater { Name = "Nancy", Number = "88", TeamId = IdDCRG },
                new Skater { Name = "AKA Rouge", Number = "07", TeamId = IdDCRG },
                new Skater { Name = "Billie Killgrim", Number = "458", TeamId = IdDCRG },
                new Skater { Name = "Carrie A. Glock", Number = "40", TeamId = IdDCRG },
                new Skater { Name = "Contract Killer", Number = "214", TeamId = IdDCRG },
                new Skater { Name = "Dee Bunz", Number = "32", TeamId = IdDCRG },
                new Skater { Name = "E2 Brute", Number = "12", TeamId = IdDCRG },
                new Skater { Name = "Elle A. Drive-By", Number = "5", TeamId = IdDCRG },
                new Skater { Name = "Ellie Slay", Number = "17", TeamId = IdDCRG },
                new Skater { Name = "Fury Fae", Number = "3", TeamId = IdDCRG },
                new Skater { Name = "Holy Moses", Number = "10", TeamId = IdDCRG },
                new Skater { Name = "Jack B. Hasty", Number = "511", TeamId = IdDCRG },
                new Skater { Name = "Johnnie Knocks'em", Number = "808", TeamId = IdDCRG },
                new Skater { Name = "Kimmie Crippler", Number = "87", TeamId = IdDCRG },
                new Skater { Name = "Lady Painicorn", Number = "999", TeamId = IdDCRG },
                new Skater { Name = "Little Bunny Slew You", Number = "37", TeamId = IdDCRG },
                new Skater { Name = "Mace Freely", Number = "155", TeamId = IdDCRG },
                new Skater { Name = "Stiches", Number = "71", TeamId = IdGGB },
                new Skater { Name = "Dr. PsychoDella", Number = "137", TeamId = IdGGB },
                new Skater { Name = "Dirty Dee'd", Number = "66", TeamId = IdGGB },
                new Skater { Name = "Wreck-It Rach", Number = "29", TeamId = IdGGB },
                new Skater { Name = "Cynistar", Number = "6", TeamId = IdGGB },
                new Skater { Name = "Barbie Bruiser", Number = "33", TeamId = IdGGB },
                new Skater { Name = "AntiJen", Number = "244", TeamId = IdGGB },
                new Skater { Name = "Romaine Event", Number = "82", TeamId = IdGGB },
                new Skater { Name = "Tenacious Taffy", Number = "16", TeamId = IdGGB },
                new Skater { Name = "Kooks Deluxe", Number = "41", TeamId = IdGGB },
                new Skater { Name = "Baby Cakes", Number = "86", TeamId = IdGGB });

            db.SaveChanges();

        }
    }
}
