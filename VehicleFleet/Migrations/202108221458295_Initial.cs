namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegisterShifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOfBeginning = c.DateTime(nullable: false),
                        TimeOfEnd = c.DateTime(nullable: false),
                        DriverId = c.Int(nullable: false),
                        Mileage = c.Single(nullable: false),
                        FuelConsumption = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EngineHP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisterShifts", "DriverId", "dbo.Drivers");
            DropIndex("dbo.RegisterShifts", new[] { "DriverId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.RegisterShifts");
            DropTable("dbo.Drivers");
        }
    }
}
