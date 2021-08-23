namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicle : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vehicles", name: "DriverId", newName: "Driver_Id");
            RenameIndex(table: "dbo.Vehicles", name: "IX_DriverId", newName: "IX_Driver_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vehicles", name: "IX_Driver_Id", newName: "IX_DriverId");
            RenameColumn(table: "dbo.Vehicles", name: "Driver_Id", newName: "DriverId");
        }
    }
}
