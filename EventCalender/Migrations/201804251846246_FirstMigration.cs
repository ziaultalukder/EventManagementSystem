namespace EventCalender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventDetailsId = c.Int(nullable: false, identity: true),
                        EventTypeId = c.Int(nullable: false),
                        EventVanueId = c.Int(nullable: false),
                        EventTitle = c.String(maxLength: 255),
                        EventStartTime = c.DateTime(nullable: false),
                        EventEndTime = c.DateTime(nullable: false),
                        EventMaxTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventDetailsId);
            
            CreateTable(
                "dbo.EventVanue",
                c => new
                    {
                        EventVanueId = c.Int(nullable: false, identity: true),
                        EventVanueName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EventVanueId);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        EventTypeName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventType");
            DropTable("dbo.EventVanue");
            DropTable("dbo.EventDetails");
        }
    }
}
