namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initLaptop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeatherAlerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlertType = c.String(nullable: false, maxLength: 30),
                        AlertMessage = c.String(nullable: false, maxLength: 200),
                        IssuedAt = c.DateTime(nullable: false),
                        ExpiresAt = c.DateTime(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Double(nullable: false),
                        Humidity = c.Int(nullable: false),
                        Condition = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weathers", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.WeatherAlerts", "LocationId", "dbo.Locations");
            DropIndex("dbo.Weathers", new[] { "LocationId" });
            DropIndex("dbo.WeatherAlerts", new[] { "LocationId" });
            DropTable("dbo.Weathers");
            DropTable("dbo.WeatherAlerts");
            DropTable("dbo.Locations");
        }
    }
}
