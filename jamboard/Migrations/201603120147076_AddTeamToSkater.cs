namespace jamboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamToSkater : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skaters", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skaters", "TeamId");
            AddForeignKey("dbo.Skaters", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skaters", "TeamId", "dbo.Teams");
            DropIndex("dbo.Skaters", new[] { "TeamId" });
            DropColumn("dbo.Skaters", "TeamId");
        }
    }
}
