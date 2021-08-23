namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleAndDriverModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DriverId", c => c.Int());
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropColumn("dbo.Vehicles", "DriverId");
        }
    }
}
