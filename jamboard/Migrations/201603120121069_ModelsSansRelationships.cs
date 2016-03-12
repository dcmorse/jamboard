namespace jamboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsSansRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
            DropTable("dbo.Jams");
        }
    }
}
