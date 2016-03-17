namespace jamboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkaterIsSkatingProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skaters", "IsSkating", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skaters", "IsSkating");
        }
    }
}
