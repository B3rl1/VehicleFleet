namespace VehicleFleet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditVehicleModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "EngineVolume", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "EngineVolume", c => c.Single(nullable: false));
        }
    }
}
