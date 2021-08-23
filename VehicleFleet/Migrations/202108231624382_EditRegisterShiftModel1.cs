namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRegisterShiftModel1 : DbMigration
    {
	    public override void Up()
	    {
		    AlterColumn("dbo.RegisterShifts", "FuelConsumption", c => c.Single(nullable: false));
		    AlterColumn("dbo.RegisterShifts", "Mileage", c => c.Single(nullable: false));
	    }

	    public override void Down()
	    {
		    AlterColumn("dbo.RegisterShifts", "Mileage", c => c.Int(nullable: false));
		    AlterColumn("dbo.RegisterShifts", "FuelConsumption", c => c.Int(nullable: false));
	    }
    }
}
