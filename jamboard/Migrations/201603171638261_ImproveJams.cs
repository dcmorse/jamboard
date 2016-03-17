namespace jamboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImproveJams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkaterJams",
                c => new
                    {
                        Skater_Id = c.Int(nullable: false),
                        Jam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skater_Id, t.Jam_Id })
                .ForeignKey("dbo.Skaters", t => t.Skater_Id, cascadeDelete: true)
                .ForeignKey("dbo.Jams", t => t.Jam_Id, cascadeDelete: true)
                .Index(t => t.Skater_Id)
                .Index(t => t.Jam_Id);
            
            AddColumn("dbo.Jams", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.Jams", "Timestamp", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Jams", "TeamId");
            AddForeignKey("dbo.Jams", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jams", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.SkaterJams", "Jam_Id", "dbo.Jams");
            DropForeignKey("dbo.SkaterJams", "Skater_Id", "dbo.Skaters");
            DropIndex("dbo.SkaterJams", new[] { "Jam_Id" });
            DropIndex("dbo.SkaterJams", new[] { "Skater_Id" });
            DropIndex("dbo.Jams", new[] { "TeamId" });
            DropColumn("dbo.Jams", "Timestamp");
            DropColumn("dbo.Jams", "TeamId");
            DropTable("dbo.SkaterJams");
        }
    }
}
