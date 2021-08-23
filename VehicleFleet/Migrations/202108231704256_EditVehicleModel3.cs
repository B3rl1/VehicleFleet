namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterShifts", "Mileage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RegisterShifts", "FuelConsumption", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterShifts", "FuelConsumption", c => c.Single(nullable: false));
            AlterColumn("dbo.RegisterShifts", "Mileage", c => c.Single(nullable: false));
        }
    }
}
