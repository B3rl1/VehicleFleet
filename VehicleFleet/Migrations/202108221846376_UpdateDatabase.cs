namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
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

	        AddColumn("dbo.Drivers", "FullName", c => c.String());

			AddColumn("dbo.RegisterShifts", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.RegisterShifts", "VehicleId");
            AddForeignKey("dbo.RegisterShifts", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
		{
			
		}
    }
}
